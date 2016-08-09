using System.Collections.Generic;
using Entitas;

public class FireCleanupSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.Fired;
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Fired.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            e.isCharging = false;
            e.isFired = false;
        }
    }
}