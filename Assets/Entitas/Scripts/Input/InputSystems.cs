using Entitas;

public class InputSystems : Feature
{
    public InputSystems(Pool pool) : base("InputSystems")
    {
        Add(pool.CreateSystem<HorizontalAxisInputSystem>());

        Add(pool.CreateSystem<VerticalAxisInputSystem>());

        Add(pool.CreateSystem<FireInputDownSystem>());
        Add(pool.CreateSystem<FireInputUpSystem>());
    }
}