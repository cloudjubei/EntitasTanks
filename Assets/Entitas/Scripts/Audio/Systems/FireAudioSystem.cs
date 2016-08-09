using System.Collections.Generic;
using Entitas;

public class FireAudioSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Tank, Matcher.GameObject, Matcher.Fired);
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
            e.GetTankAudio().PlayShotFire();
        }
    }
}