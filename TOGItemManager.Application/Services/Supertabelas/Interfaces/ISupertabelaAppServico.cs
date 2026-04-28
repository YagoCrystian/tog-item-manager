using TOGItemManager.Application.DTOs.Supertabelas.Requests;
using TOGItemManager.Application.DTOs.Supertabelas.Responses;
using TOGItemManager.Domain.Entidades.Supertabelas;

namespace TOGItemManager.Application.Services.Supertabelas.Interfaces
{
    public interface ISupertabelaAppServico
    {
        Supertabela ObterEValidar(int id);
        void Inserir(SupertabelaInserirRequest request);
        void Atualizar(SupertabelaUpdateRequest request);
        void Remover(int id);
        SupertabelaResponse ObterPorId(int id);
    }
}