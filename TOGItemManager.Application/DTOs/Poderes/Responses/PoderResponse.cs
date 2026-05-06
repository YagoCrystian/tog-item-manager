namespace TOGItemManager.Application.DTOs.Poderes.Responses
{
    public record PoderResponse(
        int Id, 
        string Nome, 
        string TipoPoder, 
        string Descricao
        );

}