using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Items.Requests;
using TOGItemManager.Application.DTOs.Items.Responses;

namespace TOGItemManager.Application.Services.Items.Interfaces
{
    public interface IItemAppServico
    {
        void Inserir(ItemInserirRequest request);
        void Atualizar(ItemUpdateRequest request);
        void AtualizarParcial(ItemPatchRequest request);
        void Remover(int id);
        ItemResponse ObterPorId(int id);
        PaginacaoResponse<ItemResponse> Query(ItemFiltrarRequest filtro);
        void AdicionarItemAoAndar(int itemId, int andarId);
    }
}