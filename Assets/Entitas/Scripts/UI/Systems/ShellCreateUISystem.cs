using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ShellCreateUISystem : ASystem, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
    protected GameObject ShellPrefab = Resources.Load<GameObject>("EntitasShell");

    public IMatcher ensureComponents
    {
        get
        {
			return Matcher.AllOf(Matcher.Shell, Matcher.StartPosition, Matcher.StartRotation, Matcher.StartVelocity);
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
			return Matcher.AllOf(Matcher.Shell, Matcher.StartPosition, Matcher.StartRotation, Matcher.StartVelocity).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
			GameObject o = GameObject.Instantiate(ShellPrefab, e.startPosition.value, e.startRotation.value) as GameObject;

            o.LinkEntity(e);

			o.GetComponent<Rigidbody>().velocity = e.startVelocity.value;
        }
    }
}