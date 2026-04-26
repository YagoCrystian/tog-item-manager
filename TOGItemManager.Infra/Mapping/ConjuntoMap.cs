using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.Conjuntos;

namespace TOGItemManager.Infra.Mapping
{
    public class ConjuntoMap : ClassMap<Conjunto>
    {
        public ConjuntoMap()
        {
            Schema("togitemmanager");
            Table("Conjunto");

            Id(x => x.Id).Column("Id").GeneratedBy.Identity().Not.Nullable();
            Map(x => x.Nome).Column("Nome").Not.Nullable().Length(30);
        }
    }
}