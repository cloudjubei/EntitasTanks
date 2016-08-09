using Entitas;

public class FireLaunchForceComponent : IComponent
{
    public float value, min, max;
}

public static class FireLaunchForceComponentExtension
{
    public static Entity ReplaceFireLaunchForce(this Entity e, float value)
    {
        return e.ReplaceFireLaunchForce(value, e.fireLaunchForce.min, e.fireLaunchForce.max);
    }
}