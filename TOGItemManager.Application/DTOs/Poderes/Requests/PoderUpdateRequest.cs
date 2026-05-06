namespace TOGItemManager.Application.DTOs.Poderes.Requests
{
    public class PoderUpdateRequest
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? TipoPoder { get; set; }
        public string? Descricao { get; set; }
    }
}