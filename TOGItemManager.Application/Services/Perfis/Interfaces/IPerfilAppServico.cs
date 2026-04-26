using TOGItemManager.Application.DTOs.Perfis.Requests;
using TOGItemManager.Domain.Entidades.Perfis;

namespace TOGItemManager.Application.Services.Perfis.Interfaces
{
    public interface IPerfilAppServico
    {
        Perfil ObterEValidar(int id);
        void Inserir(PerfilInserirRequest request);
        void Atualizar(PerfilUpdateRequest request);
        void Remover(int id);
    }
}