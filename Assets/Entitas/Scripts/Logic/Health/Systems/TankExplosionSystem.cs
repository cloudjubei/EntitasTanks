using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class TankExplosionSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
			return Matcher.AllOf(Matcher.Tank, Matcher.GameObject, Matcher.Destroyed);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Destroyed.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            Entity explosion = pool.CreateEntity();

			explosion.AddStartPosition(e.GetPosition());
            explosion.AddLifeTime(Time.time + 0.5f);
        }
    }
}