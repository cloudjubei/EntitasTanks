using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class TankHitSystem : ASystem, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
    public IMatcher ensureComponents
    {
        get
        {
			return Matcher.AllOf(Matcher.Tank, Matcher.GameObject, Matcher.Hit, Matcher.Health);
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
            float damage = CalculateDamage(e);

            e.ReplaceHealth(e.health.value - damage);
        }
    }

    float CalculateDamage(Entity e)
    {
		Vector3 explosionToTarget = e.GetPosition() - e.hit.hitPosition;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (e.hit.explosionRadius - explosionDistance) / e.hit.explosionRadius;

        float damage = relativeDistance * e.hit.damage;

		return Mathf.Max(0f, damage);
    }
}