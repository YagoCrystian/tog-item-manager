using System.ComponentModel;

namespace TOGItemManager.Domain.Enums
{
    public enum TipoBonusEnum
    {
        [Description("PERICIA")]
        PERICIA = 1,
        [Description("ATRIBUTO")]
        ATRIBUTO = 2,
        [Description("HABILIDADE")]
        HABILIDADE = 3,
        [Description("ITEM")]
        ITEM = 4,
    }
}