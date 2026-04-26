namespace TOGItemManager.Application.DTOs.Items.Requests
{
    public record ItemUpdateRequest(int Id, string Nome, string Descricao, string Efeito, float Valor, string Dono, int Categoria, int Raridade, int Conjunto);

}