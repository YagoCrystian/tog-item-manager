using TOGItemManager.Application.DTOs.Comuns.Requests;
using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Application.DTOs.Usuarios.Requests
{
    public class UsuarioFiltrarRequest : PaginacaoRequest
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public string? Email { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataModificado { get; set; }
        public StatusUsuarioEnum? Status { get; set; }
        public int? Perfil { get; set; }
        
    }
}