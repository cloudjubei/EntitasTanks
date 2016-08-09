using System.Collections.Generic;
using Entitas;

public class TankRecoilSystem : ASystem, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Tank, Matcher.Hit, Matcher.GameObject);
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
            return Matcher.Hit.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            e.GetRigidbody().AddExplosionForce(e.hit.explosionForce, e.hit.hitPosition, e.hit.explosionRadius);
        }
    }
}