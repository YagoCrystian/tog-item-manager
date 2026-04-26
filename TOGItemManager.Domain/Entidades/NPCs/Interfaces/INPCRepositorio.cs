namespace TOGItemManager.Domain.Entidades.NPCs.Interfaces
{
    public interface INPCRepositorio
    {
        void Inserir(NPC npc);
        void Remover(NPC npc);
        void Atualizar(NPC npc);
        NPC ObterPorId(int id);
        IQueryable<NPC> Query();
    }
}