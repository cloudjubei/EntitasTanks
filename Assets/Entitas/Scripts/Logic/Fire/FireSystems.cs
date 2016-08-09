using Entitas;

public class FireSystems : Feature
{
    public FireSystems(Pool pool) : base("FireSystems")
    {
        Add(pool.CreateSystem<AutoFireSystem>());
        Add(pool.CreateSystem<FireSystem>());

        Add(pool.CreateSystem<FireChargeSystem>());
        Add(pool.CreateSystem<FireChargingStartSystem>());

        Add(pool.CreateSystem<BulletCollisionSystem>());

        Add(pool.CreateSystem<FireCleanupSystem>());
        Add(pool.CreateSystem<ChargeCleanupSystem>());
    }
}
