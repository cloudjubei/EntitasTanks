using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RoundStartSystem : ASystem, IReactiveSystem, IInitializeSystem, IEnsureComponents
{
    protected Group winners, tanks;

    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Round, Matcher.RoundPhase, Matcher.RoundNumber);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.RoundPhase.OnEntityAdded();
        }
    }

    public void Initialize()
    {
		winners = pool.GetGroup(Matcher.AllOf(Matcher.Player, Matcher.Winner));
		tanks = pool.GetGroup(Matcher.AllOf(Matcher.Tank, Matcher.GameObject, Matcher.StartPosition, Matcher.Health));
    }

    public void Execute(List<Entity> entities)
    {
        Entity round = pool.roundEntity;

        if(round.roundPhase.value == RoundPhase.Start)
		{
			pool.isControlEnabled = false;

            foreach(Entity player in winners.GetEntities())
            {
                player.isWinner = false;
            }

			foreach(Entity tank in tanks.GetEntities()){
				tank.ReplaceHealth(tank.health.max);
				tank.GetTransform().position = tank.startPosition.value;
				tank.GetTransform().rotation = tank.startRotation.value;
				tank.isCharging = false;
				tank.isDestroyed = false;
			}

            round.ReplaceRoundNumber(round.roundNumber.value + 1);
            round.AddWait(Time.time + 3.0f);
        }
    }
}