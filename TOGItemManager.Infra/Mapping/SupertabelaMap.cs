using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.Supertabelas;

namespace TOGItemManager.Infra.Mapping
{
    public class SupertabelaMap : ClassMap<Supertabela>
    {
        public SupertabelaMap()
        {
            Schema("togitemmanager");
            Table("supertabela");

            Id(s => s.Id).Column("Id").GeneratedBy.Identity();
            Map(s =>s.NP).Column("NP").Not.Nullable();
            Map(s =>s.Velocidade).Column("Velocidade").Not.Nullable();
            Map(s =>s.Carga).Column("Carga").Not.Nullable();
            Map(s => s.DanoCura).Length(10).Column("DanoCura").Not.Nullable();
            Map(s => s.BonusDano).Column("BonusDano").Not.Nullable();
            Map(s => s.Distancia).Column("Distancia").Not.Nullable();
            Map(s => s.Multiplicador).Column("Multiplicador").Not.Nullable();
        }
    }
}