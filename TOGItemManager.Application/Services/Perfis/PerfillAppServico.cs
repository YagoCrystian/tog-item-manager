using TOGItemManager.Application.DTOs.Perfis.Requests;
using TOGItemManager.Application.Services.Perfis.Interfaces;
using TOGItemManager.Domain.Entidades.Perfis;
using TOGItemManager.Domain.Entidades.Perfis.Interfaces;

namespace TOGItemManager.Application.Services.Perfis
{
    public class PerfilAppServico : IPerfilAppServico
    {
        private readonly IPerfilRepositorio perfilRepositorio;

        public PerfilAppServico(IPerfilRepositorio perfilRepositorio)
        {
            this.perfilRepositorio = perfilRepositorio;
        }

        public Perfil ObterEValidar(int id)
        {
            Perfil perfil = perfilRepositorio.ObterPorId(id);

            if (perfil == null)
                throw new ArgumentException("Perfil não encontrado!");

            return perfil;
        }

        public void Inserir(PerfilInserirRequest request)
        {
            Perfil perfil = new Perfil(request.PerfilTipo, request.Descricao);

            perfilRepositorio.Inserir(perfil);
        }

        public void Atualizar(PerfilUpdateRequest request)
        {
            Perfil perfil = ObterEValidar(request.Id);
            
            perfil.SetDescricao(request.Descricao);

            perfilRepositorio.Atualizar(perfil);
        }

        public void Remover(int id)
        {
            Perfil perfil = ObterEValidar(id);

            perfilRepositorio.Remover(perfil);
        }
    }
}