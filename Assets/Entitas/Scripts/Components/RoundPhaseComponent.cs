using Entitas;

public enum RoundPhase
{
    Start,
    Running,
    End
}

public class RoundPhaseComponent : IComponent
{
    public RoundPhase value;
}