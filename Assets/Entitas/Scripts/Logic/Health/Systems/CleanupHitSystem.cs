using System.Collections.Generic;
using Entitas;

public class CleanupHitSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.Hit;
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Hit.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            e.RemoveHit();
        }
    }
}