using System.Collections.Generic;
using Entitas;

public class CleanupMoveSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.Move;
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Move.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            e.RemoveMove();
        }
    }
}