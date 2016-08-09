using System.Collections.Generic;
using Entitas;

public class HealthUpdateUISystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Tank, Matcher.GameObject, Matcher.Health);
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
            e.GetTankView().UpdateHealth(e.health.value / e.health.max);
        }
    }
}