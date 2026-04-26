using TOGItemManager.Application.DTOs.Andares.Requests;
using TOGItemManager.Application.DTOs.Andares.Responses;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Items.Responses;
using TOGItemManager.Domain.Entidades.Andares;

namespace TOGItemManager.Application.Services.Andares.Interfaces
{
    public interface IAndarAppServico
    {
        void Inserir(AndarInserirRequest request);
        void Atualizar(AndarUpdateRequest request);
        void Remover(int id);
        Andar ObterPorId(int id);
        PaginacaoResponse<AndarResponse> Query(AndarFiltrarRequest filtro);
        IList<ItemResponse> ListarItensDoAndar(int andarId);

    }
}