using Entitas;
using UnityEngine;

public class LifeTimeSystem : ASystem, IExecuteSystem, IInitializeSystem
{
    protected Group entities;

    public void Initialize()
    {
        entities = pool.GetGroup(Matcher.AllOf(Matcher.LifeTime).NoneOf(Matcher.Destroyed));
    }

    public void Execute()
    {
        float time = Time.time;

        foreach (Entity e in entities.GetEntities())
        {
            if(time >= e.lifeTime.value)
            {
                e.isDestroyed = true;
            }
        }
    }
}