using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FireSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Tank, Matcher.FireLaunchForce, Matcher.GameObject, Matcher.Fired);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Fired.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            TankViewBehaviour view = e.GetTankView();

            Entity shell = pool.CreateEntity();

            shell.isShell = true;
			shell.AddStartPosition(view.FireTransform.position);
            shell.AddStartRotation(view.FireTransform.rotation);
			shell.AddStartVelocity(e.fireLaunchForce.value * view.FireTransform.forward);
            shell.AddLifeTime(Time.time + 2);   
        }
    }
}