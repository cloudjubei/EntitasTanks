using Entitas;

public class CameraSystems : Feature
{
    public CameraSystems(Pool pool) : base("CameraSystems")
    {
        Add(pool.CreateSystem<CameraMoveSystem>());

        Add(pool.CreateSystem<CameraZoomSystem>());
    }
}