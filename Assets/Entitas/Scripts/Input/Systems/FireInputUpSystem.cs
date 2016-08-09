using Entitas;
using UnityEngine;

public class FireInputUpSystem : ASystem, IExecuteSystem, IInitializeSystem
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

        foreach (Entity e in tanks.GetEntities())
		{
			int id = e.id.value;

			if(Input.GetButtonUp("Fire" + id))
            {
                e.isFired = true;
            }
        }
    }
}