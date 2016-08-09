using Entitas;

public class HealthComponent : IComponent
{
    public float value, max;
}

public static class HealthComponentExtension
{
    public static Entity ReplaceHealth(this Entity e, float value)
    {
        return e.ReplaceHealth(value, e.health.max);
    }
}