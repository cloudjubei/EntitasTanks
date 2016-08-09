using Entitas;
using UnityEngine;

public class RoundWaitSystem : ASystem, IExecuteSystem, IInitializeSystem
{
    protected Group entities;

    public void Initialize()
    {
        entities = pool.GetGroup(Matcher.AllOf(Matcher.Round, Matcher.Wait).NoneOf(Matcher.Finished));
    }

    public void Execute()
    {
        float time = Time.time;

        foreach (Entity e in entities.GetEntities())
        {
            if (time >= e.wait.value)
            {
                e.isFinished = true;
            }
        }
    }
}