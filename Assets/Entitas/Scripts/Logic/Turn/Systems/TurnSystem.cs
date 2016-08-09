using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class TurnSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
			return Matcher.AllOf(Matcher.Tank, Matcher.GameObject, Matcher.TurnSpeed, Matcher.Turn);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Turn.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
            float speed = e.turnSpeed.value;
            float turn = e.turn.amount;
            float deltaTime = e.turn.deltaTime;

            float turnDegrees = turn * speed * deltaTime;
            
            Quaternion turnRotation = Quaternion.Euler(0f, turnDegrees, 0f);

			e.GetRigidbody().MoveRotation(e.GetRigidbody().rotation * turnRotation);
        }
    }
}