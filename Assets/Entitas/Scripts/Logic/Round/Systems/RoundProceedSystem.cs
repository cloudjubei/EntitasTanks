using System.Collections.Generic;
using Entitas;

public class RoundProceedSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Round, Matcher.RoundPhase, Matcher.Finished);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Finished.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        Entity round = pool.roundEntity;

        round.ReplaceRoundPhase((RoundPhase)(((int)round.roundPhase.value + 1)%3));
        round.RemoveWait();
        round.isFinished = false;
    }
}