using Entitas;

public class MovementSystems : Feature
{
    public MovementSystems(Pool pool) : base("MovementSystems")
    {
        Add(pool.CreateSystem<MovementSystem>());
        Add(pool.CreateSystem<CleanupMoveSystem>());
    }
}