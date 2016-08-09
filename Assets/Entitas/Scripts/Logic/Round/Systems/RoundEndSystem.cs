using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RoundEndSystem : ASystem, IInitializeSystem, IReactiveSystem, IEnsureComponents
{
    protected Group tanks, players;

    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Round, Matcher.RoundPhase, Matcher.RoundNumber, Matcher.RequiredToWin);
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
        tanks = pool.GetGroup(Matcher.AllOf(Matcher.Tank).NoneOf(Matcher.Destroyed));
        players = pool.GetGroup(Matcher.AllOf(Matcher.Player, Matcher.Id));
    }

    public void Execute(List<Entity> entities)
    {
        Entity round = pool.roundEntity;

        if (round.roundPhase.value == RoundPhase.End)
        {
			pool.isControlEnabled = false;
		
            Entity tank = GetRoundWinner();

            if(tank != null)
            {
                Entity player = GetPlayerWithId(tank.id.value);

                int wins = player.wins.value + 1;
                player.ReplaceWins(wins);
                player.isWinner = true;

                if (wins >= round.requiredToWin.value)
                {
                    player.isGameWinner = true;
                }
            }
                        
            round.AddWait(Time.time + 3.0f);
        }
    }

    Entity GetRoundWinner()
    {
        if (tanks.count > 0)
        {
            return tanks.GetEntities()[0];
        }
        return null;
    }

    Entity GetPlayerWithId(int id)
    {
        foreach(Entity player in players.GetEntities())
        {
            if(player.id.value == id)
            {
                return player;
            }
        }
        return null;
    }
}