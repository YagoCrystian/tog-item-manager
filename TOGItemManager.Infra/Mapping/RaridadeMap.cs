using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.Raridades;

namespace TOGItemManager.Infra.Mapping
{
    public class RaridadeMap : ClassMap<Raridade>
    {   
        public RaridadeMap()
        {   
            Schema("togitemmanager");

            Table("Raridade");

            Id(x => x.Id).Column("Id").GeneratedBy.Increment().Not.Nullable();
            Map(x => x.Nome).Column("Nome").Not.Nullable().Length(25);
        }
    }
}