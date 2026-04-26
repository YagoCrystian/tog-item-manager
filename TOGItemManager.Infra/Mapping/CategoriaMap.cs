using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.Categorias;

namespace TOGItemManager.Infra.Mapping
{
    public class CategoriaMap : ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Schema("togitemmanager");
            Table("Categoria");
            
            Id(x => x.Id).Column("Id").GeneratedBy.Identity().Not.Nullable();
            Map(x => x.Nome).Column("Nome").Not.Nullable().Length(25);

        }
    }
}