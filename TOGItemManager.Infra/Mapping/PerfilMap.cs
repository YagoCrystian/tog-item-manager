using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.Perfis;

namespace TOGItemManager.Infra.Mapping
{
    public class PerfilMap : ClassMap<Perfil>
    {
        public PerfilMap()
        {
            Schema("togitemmanager");
            Table("perfil");

            Id(x => x.Id).Column("Id").GeneratedBy.Identity().Not.Nullable();

            Map(x => x.PerfilTipo).Column("PerfilEnum").Not.Nullable();
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
        }
    }
}