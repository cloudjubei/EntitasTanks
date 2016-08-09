using Entitas;

public class LogicSystems : Feature
{
    public LogicSystems(Pool pool) : base("LogicSystems")
    {
        Add(new RoundSystems(pool));

        Add(new CameraSystems(pool));

        Add(new TurnSystems(pool));

        Add(new MovementSystems(pool));

        Add(new FireSystems(pool));

        Add(new HealthSystems(pool));
    }
}