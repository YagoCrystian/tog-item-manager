using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.Extensoes.Queryable
{
    public static class QueryableExtension
    {
        public static IQueryable<T> Paginar<T>(
            this IQueryable<T> query,
            PaginacaoRequest filtro)
        {
            return query
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina);
        }
    }
}