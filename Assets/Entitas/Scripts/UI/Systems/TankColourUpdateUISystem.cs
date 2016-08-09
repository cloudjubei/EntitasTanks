using System.Collections.Generic;
using Entitas;

public class TankColourUpdateUISystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Tank, Matcher.GameObject, Matcher.Colour);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Tank, Matcher.GameObject, Matcher.Colour).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            e.GetTankView().ChangeColour(e.colour.value);
        }
    }
}