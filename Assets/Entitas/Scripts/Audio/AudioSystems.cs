using Entitas;

public class AudioSystems : Feature
{
    public AudioSystems(Pool pool) : base("AudioSystems")
    {
        Add(pool.CreateSystem<MovementAudioSystem>());

        Add(pool.CreateSystem<ChargingAudioSystem>());
        Add(pool.CreateSystem<FireAudioSystem>());

        Add(pool.CreateSystem<ExplosionAudioSystem>());
    }
}