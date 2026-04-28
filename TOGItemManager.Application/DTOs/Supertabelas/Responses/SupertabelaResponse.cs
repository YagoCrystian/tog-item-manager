namespace TOGItemManager.Application.DTOs.Supertabelas.Responses
{
    public record SupertabelaResponse(
        int Id,
        int NP,
        int Velocidade,
        int Carga,
        string DanoCura,
        int BonusDano,
        decimal Distancia,
        decimal Multiplicador
    );

}