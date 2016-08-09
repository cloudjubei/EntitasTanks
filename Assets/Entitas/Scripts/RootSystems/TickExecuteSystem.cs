using System;
using Entitas;

public abstract class TickExecuteSystem : ASystem, IExecuteSystem
{
	public const int TICKS_TO_EXECUTE = 16;

    protected int ticks, ticksToExecute;

    protected TickExecuteSystem(int ticksToExecute = TICKS_TO_EXECUTE)
	{
		this.ticksToExecute = ticksToExecute;
    }

    public void Execute()
	{
		ticks++;
		if(ticks == ticksToExecute){
			TickExecute();
			ticks = 0;
		}
    }

    public abstract void TickExecute();
}