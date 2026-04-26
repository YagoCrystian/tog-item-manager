namespace TOGItemManager.Application.DTOs.Comuns.Requests
{
    public class PaginacaoRequest
    {
        public int Pagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
        public string SortBy { get; set; } = "Id";
        public string Direction { get; set; } = "asc";
    }
}