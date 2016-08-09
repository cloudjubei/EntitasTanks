using System.Collections.Generic;
using Entitas;

public class TankRespawnUISystem : ASystem, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
	public IMatcher ensureComponents
	{
		get
		{
			return Matcher.AllOf(Matcher.Tank, Matcher.GameObject);
		}
	}

	public IMatcher excludeComponents
	{
		get
		{
			return Matcher.Destroyed;
		}
	}
		
	public TriggerOnEvent trigger
	{
		get
		{
			return Matcher.Destroyed.OnEntityRemoved();
		}
	}

	public void Execute(List<Entity> entities)
	{
		foreach (Entity e in entities)
		{
			e.GetTankView().ShowStart();
		}
	}
}