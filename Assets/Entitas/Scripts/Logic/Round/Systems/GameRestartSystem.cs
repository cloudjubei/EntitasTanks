using System.Collections.Generic;
using Entitas;

public class GameRestartSystem : ASystem, IInitializeSystem, IReactiveSystem, IEnsureComponents
{
    protected Group gameWinners, players;

    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.AllOf(Matcher.Round, Matcher.RoundPhase, Matcher.Finished);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Finished.OnEntityAdded();
        }
    }

    public void Initialize()
    {
        gameWinners = pool.GetGroup(Matcher.AllOf(Matcher.Player, Matcher.GameWinner));
        players = pool.GetGroup(Matcher.Player);
    }

    public void Execute(List<Entity> entities)
    {
        Entity round = pool.roundEntity;

        if (round.roundPhase.value == RoundPhase.End)
        {
            if(gameWinners.count > 0)
            {
                foreach(Entity player in players.GetEntities())
                {
                    player.isGameWinner = false;
                    player.isWinner = false;
                    player.ReplaceWins(0);
                }

                round.ReplaceRoundNumber(0);
            }
        }
    }
}