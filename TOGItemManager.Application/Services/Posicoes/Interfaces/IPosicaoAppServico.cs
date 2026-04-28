using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Posicoes.Requests;
using TOGItemManager.Application.DTOs.Posicoes.Responses;
using TOGItemManager.Domain.Entidades.Posicoes;

namespace TOGItemManager.Application.Services.Posicoes.Interfaces
{
    public interface IPosicaoAppServico
    {
        Posicao ObterEValidar(int id);
        void Inserir(PosicaoInserirRequest request);
        void Atualizar(PosicaoUpdateRequest request);
        void Remover(int id);
        PaginacaoResponse<PosicaoResponse> Query(PosicaoFiltrarRequest filtro);
    }
}