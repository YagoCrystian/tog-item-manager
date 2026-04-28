using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.DTOs.Posicoes.Requests
{
    public class PosicaoFiltrarRequest : PaginacaoRequest
    {
        public string? Nome { get; set; }
    }
}