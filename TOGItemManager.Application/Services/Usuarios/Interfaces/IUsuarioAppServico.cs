using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Usuarios.Requests;
using TOGItemManager.Application.DTOs.Usuarios.Responses;
using TOGItemManager.Domain.Entidades.Usuarios;

namespace TOGItemManager.Application.Services.Usuarios.Interfaces
{
    public interface IUsuarioAppServico
    {
        Usuario ObterEValidar(int id);
        void Inserir(UsuarioInserirRequest request);
        void Atualizar(UsuarioUpdateRequest request);
        void AlterarStatus(int id);        
        PaginacaoResponse<UsuarioResponse> Query(UsuarioFiltrarRequest filtro);
    }
}