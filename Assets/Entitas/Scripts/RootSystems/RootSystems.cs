using Entitas;

public class RootSystems : Feature
{
    public RootSystems(Pool pool) : base("RootSystems")
	{
		Add(new InputSystems(pool));

        Add(new AudioSystems(pool));

        Add(new UISystems(pool));

        Add(pool.CreateSystem<CleanupSystem>());

        Add(new LogicSystems(pool));
	}
}
