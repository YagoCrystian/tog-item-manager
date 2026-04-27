using System.Security.Cryptography.Xml;
using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.BackgroundsBonus;

namespace TOGItemManager.Infra.Mapping
{
    public class BackgroundBonusMap : ClassMap<BackgroundBonus>
    {
        public BackgroundBonusMap()
        {
            Schema("togitemmanager");
            Table("background_bonus");

            Id(b => b.Id).Column("Id").GeneratedBy.Identity().Not.Nullable();

            Map(b => b.TipoBonus).Column("TipoBonus").Not.Nullable();
            Map(b => b.Referencia).Column("ReferenciaId").Not.Nullable();
            Map(b => b.Valor).Column("Valor").Not.Nullable();
            Map(b => b.EscolhaJogador).Column("EscolhaJogador").Not.Nullable();

            References(bb => bb.Background).Column("BackgroundId").Not.Nullable();
        }
    }
}