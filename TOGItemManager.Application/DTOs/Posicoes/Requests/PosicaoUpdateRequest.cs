namespace TOGItemManager.Application.DTOs.Posicoes.Requests
{
    public class PosicaoUpdateRequest
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

    }
}