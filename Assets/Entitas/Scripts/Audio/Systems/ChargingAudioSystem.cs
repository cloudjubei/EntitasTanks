using System.Collections.Generic;
using Entitas;

public class ChargingAudioSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Tank, Matcher.GameObject, Matcher.Charging);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Charging.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            e.GetTankAudio().PlayShotCharging();
        }
    }
}