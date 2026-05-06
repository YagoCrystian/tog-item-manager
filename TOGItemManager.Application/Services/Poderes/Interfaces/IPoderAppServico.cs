using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Poderes.Requests;
using TOGItemManager.Application.DTOs.Poderes.Responses;
using TOGItemManager.Domain.Entidades.Poderes;

namespace TOGItemManager.Application.Services.Poderes.Interfaces
{
    public interface IPoderAppServico
    {
        Poder ObterEValidar(int id);
        void Inserir(PoderInserirRequest request);
        void Atualizar(PoderUpdateRequest request);
        void Remover(int id);
        PaginacaoResponse<PoderResponse> Query(PoderFiltrarRequest filtro);
    }
}