using System.Collections.Generic;
using Entitas;

public class ShellDestroyedUISystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Shell, Matcher.GameObject, Matcher.ShouldBeDestroyed);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.ShouldBeDestroyed.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            e.GetShellBehaviour().ShowDeath();
            e.isDestroyed = true;
        }
    }
}