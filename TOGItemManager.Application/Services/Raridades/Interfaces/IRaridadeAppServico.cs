using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Raridades.Requests;
using TOGItemManager.Application.DTOs.Raridades.Responses;

namespace TOGItemManager.Application.Services.Raridades.Interfaces
{
    public interface IRaridadeAppServico
    {
        void Inserir(RaridadeCreateRequest request);
        void Atualizar(RaridadeUpdateRequest request);
        void Remover(int id);
        RaridadeResponse ObterPorId(int id);
        public PaginacaoResponse<RaridadeResponse> Query(RaridadeFiltrarRequest filtro);
    }
}