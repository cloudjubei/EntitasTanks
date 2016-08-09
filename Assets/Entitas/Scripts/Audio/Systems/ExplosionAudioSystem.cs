using System.Collections.Generic;
using Entitas;

public class ExplosionAudioSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Explosion, Matcher.GameObject);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Explosion, Matcher.GameObject).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            e.GetExplosionAudio().PlayExplosion();
        }
    }
}