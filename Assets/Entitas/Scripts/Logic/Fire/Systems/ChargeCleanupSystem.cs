using System.Collections.Generic;
using Entitas;

public class ChargeCleanupSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.Charge;
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Charge.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            e.RemoveCharge();
        }
    }
}