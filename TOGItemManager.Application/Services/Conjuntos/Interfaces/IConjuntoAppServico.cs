using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Conjuntos.Requests;
using TOGItemManager.Application.DTOs.Conjuntos.Responses;

namespace TOGItemManager.Application.Services.Conjuntos.Interfaces
{
    public interface IConjuntoAppServico
    {
        void Inserir(ConjuntoInserirRequest request);
        void Atualizar(ConjuntoUpdateRequest request);
        void Remover(int id);
        ConjuntoResponse ObterPorId(int id);
        PaginacaoResponse<ConjuntoResponse> Query(ConjuntoFiltrarRequest filtro);
    }
}