using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Posicoes.Requests;
using TOGItemManager.Application.DTOs.Posicoes.Responses;
using TOGItemManager.Application.DTOs.PosicoesBonus.Responses;
using TOGItemManager.Application.Extensoes.Queryable;
using TOGItemManager.Application.Services.Posicoes.Interfaces;
using TOGItemManager.Domain.Entidades.Posicoes;
using TOGItemManager.Domain.Entidades.Posicoes.Interfaces;

namespace TOGItemManager.Application.Services.Posicoes
{
    public class PosicaoAppServico : IPosicaoAppServico
    {
        private readonly IPosicaoRepositorio posicaoRepositorio;

        public PosicaoAppServico(IPosicaoRepositorio posicaoRepositorio)
        {
            this.posicaoRepositorio = posicaoRepositorio;
        }

        public Posicao ObterEValidar(int id)
        {
            Posicao posicao = posicaoRepositorio.ObterPorId(id);

            if (posicao == null)
                throw new ArgumentException("Posicao não encontrado.");

            return posicao;
        
        }
        public void Inserir(PosicaoInserirRequest request)
        {
            Posicao posicao = new Posicao(
                request.Nome,
                request.Descricao
            );

            posicaoRepositorio.Inserir(posicao); 
        }

        public void Atualizar(PosicaoUpdateRequest request)
        {
            Posicao posicao = ObterEValidar(request.Id);

            if(!string.IsNullOrWhiteSpace(request.Nome))
                posicao.SetNome(request.Nome);

            if(!string.IsNullOrWhiteSpace(request.Descricao))
                posicao.SetDescricao(request.Descricao);

            posicaoRepositorio.Atualizar(posicao);
        }

        public void Remover(int id)
        {
            Posicao posicao = ObterEValidar(id);
            
            posicaoRepositorio.Remover(posicao);
        }

        public PaginacaoResponse<PosicaoResponse> Query(PosicaoFiltrarRequest filtro)
        {
            var query = posicaoRepositorio.Query();

            if (!string.IsNullOrWhiteSpace(filtro.Nome))
            {
                query = query.Where(b => b.Nome.Contains(filtro.Nome));
            }

            if(filtro.SortBy.ToLower() == "nome")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(b => b.Nome)
                    : query.OrderByDescending(b => b.Nome);
            }
            else
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(b => b.Id)
                    : query.OrderByDescending(b => b.Id);
            }

            var totalItens = query.Count();

            var posicoes = query.Paginar(filtro).ToList();

            var data = posicoes.Select(p => new PosicaoResponse(
                p.Id,
                p.Nome, 
                p.Descricao, 
                p.Bonus.Select(pb => new PosicaoBonusResponse(
                    pb.Id,
                    pb.TipoBonus,
                    pb.Referencia,
                    pb.Valor,
                    pb.PorNivel
                ))
                .ToList()))
                .ToList();

            return new PaginacaoResponse<PosicaoResponse>(
                data,
                filtro.Pagina,
                filtro.TamanhoPagina,
                totalItens
            );
        }
    }
}