namespace TOGItemManager.Application.DTOs.Comuns.Responses
{
    public class PaginacaoResponse<T>
    {
        public IList<T> Data { get; set; }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalItens { get; set; }
        public int TotalPaginas { get; set; }      
        
        public PaginacaoResponse(IList<T> data, int pagina, int tamanhoPagina, int totalItens)
        {
            Data = data;
            Pagina = pagina;
            TamanhoPagina = tamanhoPagina;
            TotalItens = totalItens;
            TotalPaginas = (int)Math.Ceiling((double)totalItens / tamanhoPagina);
        }
    }
}