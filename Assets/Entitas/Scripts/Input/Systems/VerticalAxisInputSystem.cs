using Entitas;
using UnityEngine;

public class VerticalAxisInputSystem : ASystem, IExecuteSystem, IInitializeSystem
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

        foreach(Entity e in tanks.GetEntities())
		{            
			int id = e.id.value;

			float vertical = Input.GetAxis("Vertical" + id);

            if (vertical != 0)
            {
                e.AddMove(vertical, deltaTime);
            }
        }
    }
}