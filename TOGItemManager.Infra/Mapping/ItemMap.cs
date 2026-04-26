using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.Items;

namespace TOGItemManager.Infra.Mapping
{
    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            Schema("togitemmanager");
            Table("Item");

            Id(x => x.Id).Column("Id").GeneratedBy.Identity();
            Map(x => x.Nome).Column("Nome").Not.Nullable();
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
            Map(x => x.Efeito).Column("Efeito").Not.Nullable();
            Map(x => x.Valor).Column("Valor").Not.Nullable();
            Map(x => x.Dono).Column("Dono").Nullable();
            
            References(x => x.Categoria).Column("CategoriaId").Not.Nullable();
            References(x => x.Raridade).Column("RaridadeId").Not.Nullable();
            References(x => x.Conjunto).Column("ConjuntoId").Not.Nullable();

            HasManyToMany(x => x.Andares)
                .Table("Item_Andar")
                .ParentKeyColumn("ItemId")
                .ChildKeyColumn("AndarId")
                .Cascade.None();
        }
    }
}