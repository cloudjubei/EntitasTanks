using Entitas;

public class HealthSystems : Feature
{
    public HealthSystems(Pool pool) : base("HealthSystems")
    {
        Add(pool.CreateSystem<TankHitSystem>());
        Add(pool.CreateSystem<TankRecoilSystem>());

        Add(pool.CreateSystem<LifeTimeSystem>());

        Add(pool.CreateSystem<TankDestroySystem>());

        Add(pool.CreateSystem<TankExplosionSystem>());

        Add(pool.CreateSystem<CleanupHitSystem>());
    }
}