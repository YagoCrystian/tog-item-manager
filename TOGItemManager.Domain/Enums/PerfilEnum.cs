using System.ComponentModel;

namespace TOGItemManager.Domain.Enums
{
    public enum PerfilEnum
    {
        [Description("ADMIN")]
        ADMIN = 1,
        [Description("JOGADOR")]
        JOGADOR = 2,
        [Description("MESTRE")]
        MESTRE = 3
    }
}