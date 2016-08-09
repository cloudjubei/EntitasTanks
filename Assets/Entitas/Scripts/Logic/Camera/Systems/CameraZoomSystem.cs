using Entitas;
using UnityEngine;

public class CameraZoomSystem : ASystem, IExecuteSystem, IInitializeSystem
{
    protected Group cameras, tanks;
    protected float dampVelocity;

    public void Initialize()
    {
        cameras = pool.GetGroup(Matcher.AllOf(Matcher.Camera, Matcher.GameObject));
        tanks = pool.GetGroup(Matcher.AllOf(Matcher.Tank, Matcher.GameObject).NoneOf(Matcher.Destroyed));

        foreach (Entity e in pool.GetGroup(Matcher.AllOf(Matcher.Camera, Matcher.GameObject)).GetEntities())
        {
            float requiredSize = FindRequiredSize(e);

			e.camera.value.orthographicSize = requiredSize;
        }
    }

    public void Execute()
    {
        foreach (Entity e in cameras.GetEntities())
        {
            float requiredSize = FindRequiredSize(e);

			float dampedSize = Mathf.SmoothDamp(e.camera.value.orthographicSize, requiredSize, ref dampVelocity, e.cameraSettings.dampTime);

			e.camera.value.orthographicSize = dampedSize;
        }
    }

    float FindRequiredSize(Entity e)
    {
		float aspect = e.camera.value.aspect;
		Vector3 desiredLocalPos = e.GetTransform().InverseTransformPoint(e.GetPosition());
        
        float size = 0f;

        foreach(Entity tank in tanks.GetEntities())
        {
			Vector3 targetLocalPos = e.GetTransform().InverseTransformPoint(tank.GetPosition());
            
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;
            
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));            
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / aspect);
        }
        
        size += e.cameraSettings.screenEdgeBuffer;

        size = Mathf.Max(size, e.cameraSettings.minSize);

        return size;
    }
}