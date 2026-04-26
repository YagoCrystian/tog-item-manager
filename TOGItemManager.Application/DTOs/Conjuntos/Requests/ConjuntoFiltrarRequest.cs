using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.DTOs.Conjuntos.Requests
{
    public class ConjuntoFiltrarRequest : PaginacaoRequest
    {
        public string? Nome { get; set; }
    }
}