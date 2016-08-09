using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RoundUISystem : ASystem, IInitializeSystem, IReactiveSystem, IEnsureComponents
{
    protected Group gameWinners, winners, players;

    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Round, Matcher.RoundMessage, Matcher.RoundNumber, Matcher.RoundPhase);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Round, Matcher.RoundMessage, Matcher.RoundPhase, Matcher.RoundNumber).OnEntityAdded();
        }
    }

    public void Initialize()
    {
        gameWinners = pool.GetGroup(Matcher.AllOf(Matcher.Player, Matcher.Id, Matcher.Colour, Matcher.GameWinner));
        winners = pool.GetGroup(Matcher.AllOf(Matcher.Player, Matcher.Id, Matcher.Colour, Matcher.Winner));
        players = pool.GetGroup(Matcher.AllOf(Matcher.Player, Matcher.Id, Matcher.Colour, Matcher.Wins));
    }

    public void Execute(List<Entity> entities)
    {
        Entity round = pool.roundEntity;

        if (round.roundPhase.value == RoundPhase.Start)
        {
            round.roundMessage.value.text = "ROUND " + round.roundNumber.value;
        }else if(round.roundPhase.value == RoundPhase.Running)
        {
            round.roundMessage.value.text = "";
        }else
        {
            round.roundMessage.value.text = GetEndMessage(round);
        }
    }

    string GetEndMessage(Entity round)
    {
        string message = "DRAW!";

        if(winners.count > 0)
        {
            Entity winner = winners.GetSingleEntity();

            message = "<color=#" + ColorUtility.ToHtmlStringRGB(winner.colour.value) + ">PLAYER " + winner.id.value + "</color> WINS THE ROUND!";
        }
       

		if(gameWinners.count > 0)
		{
			Entity winner = gameWinners.GetSingleEntity();

			message += "\n\n";
			message += "<color=#" + ColorUtility.ToHtmlStringRGB(winner.colour.value) + ">PLAYER " + winner.id.value + "</color> WINS THE GAME!";
			message += "\n\n";
		}else{
			message += "\n\n\n\n";
		}

        foreach(Entity player in players.GetEntities())
        {
            message += "<color=#" + ColorUtility.ToHtmlStringRGB(player.colour.value) + ">PLAYER " + player.id.value + "</color> : " + player.wins.value + " WINS\n";

        }

        return message;
    }
}