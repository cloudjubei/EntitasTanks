using System.Collections.Generic;
using Entitas;

public class RoundRunningBeginSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Round, Matcher.RoundPhase);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.RoundPhase.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        Entity round = pool.roundEntity;

        if (round.roundPhase.value == RoundPhase.Running)
		{
			pool.isControlEnabled = true;
        }
    }
}