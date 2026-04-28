using TOGItemManager.Application.DTOs.Backgrounds.Requests;
using TOGItemManager.Application.DTOs.Backgrounds.Responses;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Domain.Entidades.Backgrounds;

namespace TOGItemManager.Application.Services.Backgrounds.Interfaces
{
    public interface IBackgroundAppServico
    {
        Background ObterEValidar(int id);
        void Inserir(BackgroundInserirRequest request);
        void Atualizar(BackgroundUpdateRequest request);
        void Remover(int id);
        PaginacaoResponse<BackgroundResponse> Query(BackgroundFiltrarRequest filtro);
    }
}