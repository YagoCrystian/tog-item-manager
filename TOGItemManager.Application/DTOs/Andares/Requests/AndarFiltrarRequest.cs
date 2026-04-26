using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.DTOs.Andares.Requests
{
    public class AndarFiltrarRequest : PaginacaoRequest
    {
        public string? Nome { get; set; }
        public int? Governante { get; set; }
        public int? Administrador { get; set; }
    }
}