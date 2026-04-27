using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Usuarios.Requests;
using TOGItemManager.Application.DTOs.Usuarios.Responses;
using TOGItemManager.Application.Services.Usuarios.Interfaces;
using TOGItemManager.Domain.Entidades.Perfis;
using TOGItemManager.Domain.Entidades.Perfis.Interfaces;
using TOGItemManager.Domain.Entidades.Usuarios;
using TOGItemManager.Domain.Entidades.Usuarios.Interfaces;
using TOGItemManager.Domain.Enums;
using TOGItemManager.Application.Extensoes.Queryable;
using TOGItemManager.Application.Seguranca;


namespace TOGItemManager.Application.Services.Usuarios
{
    public class UsuarioAppServico : IUsuarioAppServico
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly IPerfilRepositorio perfilRepositorio;

        public UsuarioAppServico(IUsuarioRepositorio usuarioRepositorio, IPerfilRepositorio perfilRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.perfilRepositorio = perfilRepositorio;
        }

        public Usuario ObterEValidar(int id)
        {
            Usuario usuario = usuarioRepositorio.ObterPorId(id);

            if(usuario == null)
                throw new ArgumentException("Usuário não encontrado");

            return usuario;
        }

        public void Inserir(UsuarioInserirRequest request)
        {
            Perfil perfil = perfilRepositorio.ObterPorId(request.PerfilId);
            if(usuarioRepositorio.ExisteApelido(request.Apelido))
                throw new ArgumentException("Apelido já em uso.");

            DateTime dataCriado = DateTime.UtcNow;
            DateTime dataModificado = DateTime.UtcNow;

            var status = StatusUsuarioEnum.ATIVO;

            var senhaHash = PasswordHasher.Hash(request.Senha);

            Usuario usuario = new Usuario(
                request.Nome,
                request.Apelido,
                request.Email,
                senhaHash,
                dataCriado,
                dataModificado,
                status,
                perfil
            );

            usuarioRepositorio.Inserir(usuario);
        }

        public void Atualizar(UsuarioUpdateRequest request)
        {
            Usuario usuario = ObterEValidar(request.Id);
        
            if(!string.IsNullOrWhiteSpace(request.Nome))
                usuario.SetNome(request.Nome);
        
            if(!string.IsNullOrWhiteSpace(request.Apelido) 
                && request.Apelido != usuario.Apelido)
            {
                if(usuarioRepositorio.ExisteApelido(request.Apelido))
                    throw new ArgumentException("Apelido já está em uso");
        
                usuario.SetApelido(request.Apelido);
            }
        
            if(!string.IsNullOrWhiteSpace(request.Email))
            {
                if((DateTime.UtcNow - usuario.DataModificado).TotalHours < 72)
                    throw new ArgumentException("Email só pode ser alterado após 72 horas.");
        
                usuario.SetEmail(request.Email);
            }
        
            if(!string.IsNullOrWhiteSpace(request.Senha))
                usuario.SetSenha(PasswordHasher.Hash(request.Senha));
            
            if(request.PerfilId.HasValue)
            {
                Perfil perfil = perfilRepositorio.ObterPorId(request.PerfilId.Value);
                usuario.SetPerfil(perfil);
            }
        
            usuario.SetDataModificado(DateTime.UtcNow);
        
            usuarioRepositorio.Atualizar(usuario);
        }

        public void AlterarStatus(int id)
        {
            Usuario usuario = ObterEValidar(id);

            if(usuario.Status == StatusUsuarioEnum.ATIVO)
            {
                usuario.SetStatusUsuario(StatusUsuarioEnum.INATIVO);
            } else
            usuario.SetStatusUsuario(StatusUsuarioEnum.ATIVO);

            usuario.SetDataModificado(DateTime.UtcNow);

            usuarioRepositorio.Atualizar(usuario);
        }

        public PaginacaoResponse<UsuarioResponse> Query(UsuarioFiltrarRequest filtro)
        {
            var query = usuarioRepositorio.Query();
            
            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                query = query.Where(c => c.Nome.Contains(filtro.Nome));
            }

            if (!string.IsNullOrEmpty(filtro.Apelido))
            {
                query = query.Where(c => c.Apelido.Contains(filtro.Apelido));
            }

            if (!string.IsNullOrEmpty(filtro.Email))
            {
                query = query.Where(c => c.Email.Contains(filtro.Email));
            }

            if(filtro.DataCriacao.HasValue)
            {
                query = query.Where(c => c.DataCriacao.Date == filtro.DataCriacao.Value);
            }

            if(filtro.DataModificado.HasValue)
            {
                query = query.Where(c => c.DataModificado.Date == filtro.DataModificado.Value);
            }

            if (filtro.Status.HasValue)
            {
                query = query.Where(c => c.Status == (StatusUsuarioEnum)filtro.Status.Value);
            }

            if (filtro.Perfil.HasValue)
            {
                query = query.Where(c => c.Perfil.PerfilTipo == (PerfilEnum)filtro.Perfil.Value);
            }

            if (filtro.SortBy.ToLower() == "nome")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Nome)
                    : query.OrderByDescending(c => c.Nome);
            }
            else if (filtro.SortBy.ToLower() == "apelido")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Apelido)
                    : query.OrderByDescending(c => c.Apelido);
            }
            else if (filtro.SortBy.ToLower() == "email")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Email)
                    : query.OrderByDescending(c => c.Email);
            }
            else if (filtro.SortBy.ToLower() == "datacriacao")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.DataCriacao)
                    : query.OrderByDescending(c => c.DataCriacao);
            }
            else if (filtro.SortBy.ToLower() == "datamodificado")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.DataModificado)
                    : query.OrderByDescending(c => c.DataModificado);
            }
            else if (filtro.SortBy.ToLower() == "status")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Status)
                    : query.OrderByDescending(c => c.Status);
            }
            else if (filtro.SortBy.ToLower() == "perfil")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Perfil.Id)
                    : query.OrderByDescending(c => c.Perfil.Id);
            }

            else
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Id)
                    : query.OrderByDescending(c => c.Id);
            }

            var totalItens = query.Count();

            var usuarios = query.Paginar(filtro).ToList();

            var data = usuarios
                .Select(u => new UsuarioResponse(
                    u.Id, 
                    u.Nome, 
                    u.Apelido, 
                    u.Email, 
                    u.DataCriacao, 
                    u.DataModificado, 
                    u.Status, 
                    u.Perfil.Id
                    ))
                .ToList();

            return new PaginacaoResponse<UsuarioResponse>(
                data,
                filtro.Pagina,
                filtro.TamanhoPagina,
                totalItens
            );
        }
    }
}