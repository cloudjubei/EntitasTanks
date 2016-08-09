using System.Collections.Generic;
using Entitas;

public class CleanupTurnSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.Turn;
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Turn.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            e.RemoveTurn();
        }
    }
}