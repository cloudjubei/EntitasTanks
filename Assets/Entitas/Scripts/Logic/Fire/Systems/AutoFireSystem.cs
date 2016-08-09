using System.Collections.Generic;
using Entitas;

public class AutoFireSystem : ASystem, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Charging, Matcher.FireLaunchForce);
        }
    }

    public IMatcher excludeComponents
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
            return Matcher.FireLaunchForce.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            if(e.fireLaunchForce.value >= e.fireLaunchForce.max)
            {
                e.isFired = true;
            }
        }
    }
}