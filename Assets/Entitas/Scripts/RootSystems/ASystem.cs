
using Entitas;

public class ASystem : ISetPool
{
    protected Pool pool;

    public void SetPool(Pool pool)
    {
        this.pool = pool;
    }
}