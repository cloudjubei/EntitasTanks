using System.Collections.Generic;
using Entitas;
using System;

public class FireChargeSystem : ASystem, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Charging, Matcher.FireChargeSpeed, Matcher.FireLaunchForce, Matcher.Charge);
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
            return Matcher.Charge.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            float deltaTime = e.charge.deltaTime;
            float speed = e.fireChargeSpeed.value;
            float current = e.fireLaunchForce.value;
            float max = e.fireLaunchForce.max;

            float force = Math.Min(current + speed*deltaTime, max);

            e.ReplaceFireLaunchForce(force);
        }
    }
}