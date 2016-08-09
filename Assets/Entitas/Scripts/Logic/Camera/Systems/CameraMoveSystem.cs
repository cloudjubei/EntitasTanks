using Entitas;
using UnityEngine;

public class CameraMoveSystem : ASystem, IExecuteSystem, IInitializeSystem
{
    protected Group cameras, tanks;
    protected Vector3 dampVelocity;

    public void Initialize()
    {
		cameras = pool.GetGroup(Matcher.AllOf(Matcher.Camera, Matcher.GameObject));
        tanks = pool.GetGroup(Matcher.AllOf(Matcher.Tank, Matcher.GameObject).NoneOf(Matcher.Destroyed));

        foreach (Entity e in pool.GetGroup(Matcher.Camera).GetEntities())
        {
            Vector3 position = FindAveragePosition();

			e.gameObject.value.transform.position = new Vector3(position.x, e.GetPosition().y, position.z);
        }
    }

    public void Execute()
    {
        foreach (Entity e in cameras.GetEntities())
        {
            Vector3 position = FindAveragePosition();

			Vector3 smoothedPosition = Vector3.SmoothDamp(e.GetPosition(), position, ref dampVelocity, 0.2f);

			e.gameObject.value.transform.position = new Vector3(smoothedPosition.x, e.GetPosition().y, smoothedPosition.z);
        }
    }

    Vector3 FindAveragePosition()
    {
        Vector3 averagePos = Vector3.zero;
        int numTargets = 0;

        foreach(Entity tank in tanks.GetEntities())
        {
			averagePos += tank.GetPosition();
            numTargets++;
        }
        if(numTargets > 0)
        {
            averagePos /= numTargets;
        }

        return averagePos;
    }
}