using Entitas;

public class RoundSystems : Feature
{
    public RoundSystems(Pool pool) : base("RoundSystems")
    {
        Add(pool.CreateSystem<RoundWaitSystem>());
        Add(pool.CreateSystem<GameRestartSystem>());
        Add(pool.CreateSystem<RoundProceedSystem>());

        Add(pool.CreateSystem<RoundWinSystem>());
        Add(pool.CreateSystem<RoundStartSystem>());
        Add(pool.CreateSystem<RoundRunningBeginSystem>());
        Add(pool.CreateSystem<RoundEndSystem>());
    }
}