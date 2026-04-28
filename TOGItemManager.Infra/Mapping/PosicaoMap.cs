using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.Posicoes;

namespace TOGItemManager.Infra.Mapping
{
    public class PosicaoMap : ClassMap<Posicao>
    {
        public PosicaoMap()
        {
            Schema("togitemmanager");
            Table("posicao");

            Id(p => p.Id).Column("Id").GeneratedBy.Identity().Not.Nullable();

            Map(p => p.Nome).Column("Nome").Length(100).Not.Nullable();
            Map(p => p.Descricao).Column("Descricao").Not.Nullable();

            HasMany(b => b.Bonus)
                .KeyColumn("PosicaoId")
                .Inverse()
                .Cascade.All();
        }
    }
}