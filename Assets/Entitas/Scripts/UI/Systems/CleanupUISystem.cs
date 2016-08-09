using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class CleanupUISystem : ASystem, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.GameObject, Matcher.Destroyed);
        }
	}
	public IMatcher excludeComponents
	{
		get
		{
			return Matcher.AnyOf(Matcher.Tank);
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
            GameObject.Destroy(e.gameObject.value);
        }
    }
}