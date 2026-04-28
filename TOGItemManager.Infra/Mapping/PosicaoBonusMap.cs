using FluentNHibernate.Mapping;
using TOGItemManager.Domain.Entidades.PosicoesBonus;

namespace TOGItemManager.Infra.Mapping
{
    public class PosicaoBonusMap : ClassMap<PosicaoBonus>
    {
        public PosicaoBonusMap()
        {
            Schema("togitemmanager");
            Table("posicao_bonus");

            Id(x => x.Id).Column("Id").GeneratedBy.Identity().Not.Nullable();

            Map(pb => pb.TipoBonus).Column("TipoBonus").Not.Nullable();
            Map(pb => pb.Referencia).Column("ReferenciaId").Not.Nullable();
            Map(pb => pb.Valor).Column("Valor").Not.Nullable();
            Map(pb => pb.PorNivel).Column("PorNivel").Not.Nullable();

            References(pb => pb.Posicao).Column("PosicaoId").Not.Nullable();
        }
    }
}