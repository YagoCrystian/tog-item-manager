namespace TOGItemManager.Application.DTOs.Items.Responses
{
    public record ItemResponse(int Id, string Nome, string Descricao, string Efeito, float Valor, string Dono, int Categoria, int Raridade, int Conjunto);

}