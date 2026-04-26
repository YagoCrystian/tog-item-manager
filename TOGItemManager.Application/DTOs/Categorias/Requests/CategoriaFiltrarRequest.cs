using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.DTOs.Categorias.Requests
{
    public class CategoriaFiltrarRequest : PaginacaoRequest
    {
        public string? Nome { get; set; }
    }
}