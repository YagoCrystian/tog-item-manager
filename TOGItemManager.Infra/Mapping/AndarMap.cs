using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.Andares;

namespace TOGItemManager.Infra.Mapping
{
    public class AndarMap : ClassMap<Andar>
    {
        public AndarMap()
        {
            Schema("togitemmanager");
            Table("Andar");
            
            Id(x => x.Id).Column("Id").GeneratedBy.Identity().Not.Nullable();
            Map(x => x.Nome).Column("Nome").Not.Nullable().Length(25);

            References(x => x.Governante).Column("GovernanteId").Not.Nullable();
            References(x => x.Administrador).Column("AdministradorId").Not.Nullable();

            HasManyToMany(x => x.Itens)
                .Table("Item_Andar")
                .ParentKeyColumn("AndarId")
                .ChildKeyColumn("ItemId")
                .Inverse();

        }
    }
}