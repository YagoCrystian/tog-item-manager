namespace TOGItemManager.Application.DTOs.Supertabelas.Requests
{
    public record SupertabelaInserirRequest(
        int NP,
        int Velocidade,
        int Carga,
        string DanoCura,
        int BonusDano,
        decimal Distancia,
        decimal Multiplicador
    );

}