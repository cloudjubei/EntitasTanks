using System.Collections.Generic;
using Entitas;

public class MovementAudioSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Tank, Matcher.GameObject, Matcher.Move);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Move.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            TankAudioBehaviour audio = e.GetTankAudio();

            if (e.move.amount <= 0.1f)
            {
                audio.PlayMovementIdle();
            }
            else
            {
                audio.PlayerMovementDriving();
            }
        }
    }
}