using Entitas;
using System.Collections.Generic;

public class RoundWinSystem : ASystem, IInitializeSystem, IReactiveSystem, IEnsureComponents
{
    protected Group tanks;

    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Tank, Matcher.Destroyed);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Destroyed.OnEntityAdded();
        }
    }

    public void Initialize()
    {
        tanks = pool.GetGroup(Matcher.AllOf(Matcher.Tank).NoneOf(Matcher.Destroyed));
    }

    public void Execute(List<Entity> entities)
    {
        Entity round = pool.roundEntity;

        if(round.roundPhase.value == RoundPhase.Running && tanks.count <= 1)
        {
            round.ReplaceRoundPhase(RoundPhase.End);
        }       
    }
}