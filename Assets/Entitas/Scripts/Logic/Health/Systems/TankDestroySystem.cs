using System;
using System.Collections.Generic;
using Entitas;

public class TankDestroySystem : ASystem, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Tank, Matcher.Health);
        }
    }

    public IMatcher excludeComponents
    {
        get
        {
            return Matcher.AnyOf(Matcher.Destroyed);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Health.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            if(e.health.value <= 0)
            {
                e.isDestroyed = true;
            }
        }
    }
}