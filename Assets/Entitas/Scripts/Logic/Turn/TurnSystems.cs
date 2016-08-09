using Entitas;

public class TurnSystems : Feature
{
    public TurnSystems(Pool pool) : base("TurnSystems")
    {
        Add(pool.CreateSystem<TurnSystem>());
        Add(pool.CreateSystem<CleanupTurnSystem>());
    }
}