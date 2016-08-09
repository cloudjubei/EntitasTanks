using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class TankCreateUISystem : ASystem, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
    protected GameObject TankPrefab = Resources.Load<GameObject>("EntitasTank");

    public IMatcher ensureComponents
    {
        get
        {
			return Matcher.AllOf(Matcher.Tank, Matcher.StartPosition, Matcher.StartRotation);
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
            return Matcher.Tank.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
			GameObject o = GameObject.Instantiate(TankPrefab, e.startPosition.value, e.startRotation.value) as GameObject;

            o.LinkEntity(e);
        }
    }
}