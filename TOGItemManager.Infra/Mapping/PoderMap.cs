using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.Poderes;

namespace TOGItemManager.Infra.Mapping
{
    public class PoderMap : ClassMap<Poder>
    {
        public PoderMap()
        {
            Schema("togitemmanager");
            Table("poderes");

            Id(p => p.Id).Column("id").GeneratedBy.Identity().Not.Nullable();

            Map(p => p.Nome).Column("nome").Length(50).Not.Nullable();
            Map(p => p.TipoPoder).Column("tipopoder").Length(50).Not.Nullable();
            Map(p => p.Descricao).Column("descricao").Not.Nullable();
        }
    }
}