namespace TOGItemManager.Application.DTOs.Supertabelas.Requests
{
    public class SupertabelaUpdateRequest
    {   
        public int Id { get; set; }
        public int? NP { get; set; }
        public int? Velocidade { get; set; }
        public int? Carga { get; set; }
        public string? DanoCura { get; set; }
        public int? BonusDano { get; set; }
        public decimal? Distancia { get; set; }
        public decimal? Multiplicador { get; set; }
    }
}