using Entitas;
using UnityEngine;

public class HorizontalAxisInputSystem : ASystem, IExecuteSystem, IInitializeSystem
{
    protected Group tanks;

    public void Initialize()
    {
		tanks = pool.GetGroup(Matcher.AllOf(Matcher.Tank, Matcher.Id));
    }

    public void Execute()
    {
		if(!pool.isControlEnabled){
			return;
		}

        float deltaTime = Time.deltaTime;

        foreach (Entity e in tanks.GetEntities())
		{
			int id = e.id.value;

			float horizontal = Input.GetAxis("Horizontal" + id);

            if (horizontal != 0)
            {
                e.AddTurn(horizontal, deltaTime);
            }
        }
    }
}