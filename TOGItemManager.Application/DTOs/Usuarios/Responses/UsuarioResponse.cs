using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Application.DTOs.Usuarios.Responses
{
    public record UsuarioResponse(
        int Id,
        string Nome,
        string Apelido,
        string Email,
        DateTime DataCriacao,
        DateTime DataModificado,
        StatusUsuarioEnum Status,
        int PerfilId
    );

}