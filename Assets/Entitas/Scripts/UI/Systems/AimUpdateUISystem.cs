using System.Collections.Generic;
using Entitas;

public class AimUpdateUISystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Tank, Matcher.GameObject, Matcher.FireLaunchForce);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.FireLaunchForce, Matcher.Charging).OnEntityAddedOrRemoved();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            e.GetTankView().UpdateAim(e.isCharging ? e.fireLaunchForce.value : 0);
        }
    }
}