using Entitas;

public class UISystems : Feature
{
    public UISystems(Pool pool) : base("UISystems")
    {
        Add(pool.CreateSystem<TankCreateUISystem>());
        Add(pool.CreateSystem<TankColourUpdateUISystem>());
        Add(pool.CreateSystem<AimUpdateUISystem>());
        Add(pool.CreateSystem<HealthUpdateUISystem>());
		Add(pool.CreateSystem<TankRespawnUISystem>());
        Add(pool.CreateSystem<DestroyedUpdateUISystem>());
        
        Add(pool.CreateSystem<ExplosionCreateUISystem>());

        Add(pool.CreateSystem<ShellCreateUISystem>());
        Add(pool.CreateSystem<ShellDestroyedUISystem>());

        Add(pool.CreateSystem<RoundUISystem>());

        Add(pool.CreateSystem<CleanupUISystem>());
    }
}