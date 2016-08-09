using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class MovementSystem : ASystem, IReactiveSystem, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get {
			return Matcher.AllOf(Matcher.Tank, Matcher.GameObject, Matcher.MoveSpeed, Matcher.Move);
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
        foreach(Entity e in entities)
        {
			Vector3 direction = e.GetTransform().forward;
            float speed = e.moveSpeed.value;
            float move = e.move.amount;
            float deltaTime = e.move.deltaTime;

			Vector3 newPosition = e.GetRigidbody().position + direction * move * speed * deltaTime;

			e.GetRigidbody().MovePosition(newPosition);
        }
    }
}