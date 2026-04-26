namespace TOGItemManager.Application.DTOs.Items.Requests
{
    public class ItemPatchRequest
{
    public int Id { get; set; }

    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public string? Efeito { get; set; }
    public float? Valor { get; set; }
    public string? Dono { get; set; }

    public int? Categoria { get; set; }
    public int? Raridade { get; set; }
    public int? Conjunto { get; set; }
}
}