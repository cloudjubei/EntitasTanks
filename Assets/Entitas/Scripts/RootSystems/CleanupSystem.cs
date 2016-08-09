using System.Collections.Generic;
using Entitas;

public class CleanupSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Shell, Matcher.Destroyed);
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
        for(int i=entities.Count-1; i>=0; i--)
        {
            pool.DestroyEntity(entities[i]);
        }
    }
}