using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Application.DTOs.Usuarios.Requests
{
    public record UsuarioInserirRequest(
        string Nome,
        string Apelido,
        string Email,
        string Senha,
        DateTime DataCriado,
        DateTime DataModificado,
        StatusUsuarioEnum Status,
        int PerfilId
    );

}