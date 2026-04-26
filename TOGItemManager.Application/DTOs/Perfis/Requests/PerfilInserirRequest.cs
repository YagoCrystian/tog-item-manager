using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Application.DTOs.Perfis.Requests
{
    public record PerfilInserirRequest(PerfilEnum PerfilTipo, string Descricao);

}