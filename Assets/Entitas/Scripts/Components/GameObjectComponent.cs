using Entitas;
using UnityEngine;

public class GameObjectComponent : IComponent
{
    public GameObject value;
}

public static class GameObjectComponentExtension
{
	public static Transform GetTransform(this Entity e)
	{
		return e.gameObject.value.transform;
	}
	public static Vector3 GetPosition(this Entity e)
	{
		return e.GetTransform().position;
	}	
    public static Rigidbody GetRigidbody(this Entity e)
    {
        return e.gameObject.value.GetComponent<Rigidbody>();
    }
    public static TankViewBehaviour GetTankView(this Entity e)
    {
        return e.gameObject.value.GetComponent<TankViewBehaviour>();
    }
    public static TankAudioBehaviour GetTankAudio(this Entity e)
    {
        return e.gameObject.value.GetComponent<TankAudioBehaviour>();
    }
    public static ExplosionAudioBehaviour GetExplosionAudio(this Entity e)
    {
        return e.gameObject.value.GetComponent<ExplosionAudioBehaviour>();
    }
    public static ShellBehaviour GetShellBehaviour(this Entity e)
    {
        return e.gameObject.value.GetComponent<ShellBehaviour>();
    }
}