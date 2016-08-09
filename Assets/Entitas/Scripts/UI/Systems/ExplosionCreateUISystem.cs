using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ExplosionCreateUISystem : ASystem, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
    protected GameObject ExplosionPrefab = Resources.Load<GameObject>("EntitasExplosion");

    public IMatcher ensureComponents
    {
        get
        {
			return Matcher.AllOf(Matcher.Explosion, Matcher.StartPosition);
        }
    }

    public IMatcher excludeComponents
    {
        get
        {
            return Matcher.GameObject;
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Explosion.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
			GameObject o = GameObject.Instantiate(ExplosionPrefab, e.startPosition.value, Quaternion.identity) as GameObject;

            o.LinkEntity(e);
        }
    }
}