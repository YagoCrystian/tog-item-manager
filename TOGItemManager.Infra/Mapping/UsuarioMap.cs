using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.Usuarios;

namespace TOGItemManager.Infra.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Schema("togitemmanager");
            Table("Usuario");

            Id(x => x.Id).Column("Id").GeneratedBy.Identity().Not.Nullable();

            Map(x => x.Nome).Column("Nome").Length(120).Not.Nullable();
            Map(x => x.Apelido).Column("Apelido").Length(80).Unique().Not.Nullable();
            Map(x => x.Email).Column("Email").Length(150).Unique().Not.Nullable();
            Map(x => x.Senha).Column("PasswordHash").Length(255).Not.Nullable();
            Map(x => x.DataCriacao).Column("DataCriado").Not.Nullable();
            Map(x => x.DataModificado).Column("DataModificado").Not.Nullable();
            Map(x => x.Status).Column("Status").Not.Nullable();

            References(x => x.Perfil).Column("PerfilId").Not.Nullable();
        }
    }
}