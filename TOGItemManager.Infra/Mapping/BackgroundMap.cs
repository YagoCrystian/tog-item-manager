using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.Backgrounds;

namespace TOGItemManager.Infra.Mapping
{
    public class BackgroundMap : ClassMap<Background>
    {
        public BackgroundMap()
        {
            Schema("togitemmanager");
            Table("background");

            Id(b => b.Id).Column("Id").GeneratedBy.Identity().Not.Nullable();

            Map(b => b.Nome).Column("Nome").Length(50).Not.Nullable();
            Map(b => b.Descricao).Column("Descricao").Not.Nullable();
        }
    }
}