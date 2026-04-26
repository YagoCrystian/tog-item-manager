using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.NPCs;

namespace TOGItemManager.Infra.Mapping
{
    public class NPCMap : ClassMap<NPC>
    {
        public NPCMap()
        {
            Schema("togitemmanager");
            Table("NPC");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome).Not.Nullable().Length(100);
            Map(x => x.Tipo).Not.Nullable().Length(100);
        }
    }
}