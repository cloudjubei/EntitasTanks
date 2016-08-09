using System.Collections.Generic;
using Entitas;

public class FireChargingStartSystem : ASystem, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.FireLaunchForce, Matcher.Charge);
        }
    }

    public IMatcher excludeComponents
    {
        get
        {
            return Matcher.Charging;
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Charge.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            e.isCharging = true;
            e.ReplaceFireLaunchForce(e.fireLaunchForce.min);
        }
    }
}