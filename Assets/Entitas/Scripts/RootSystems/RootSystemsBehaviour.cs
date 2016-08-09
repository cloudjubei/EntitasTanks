using UnityEngine;
using System;
using UnityEngine.UI;
using Entitas;

public class RootSystemsBehaviour : MonoBehaviour
{
	public bool running = true;

    public int NumRoundsToWin = 5;            
    public float StartDelay = 3f;             
    public float EndDelay = 3f;
    public float CameraDampTime = 0.2f;
    public float CameraScreenEdgeBuffer = 4f;
    public float CameraMinSize = 6.5f;
    public Text MessageText;                 
    public TankSetupInfo[] Tanks;              

    public RootSystems rootSystems;

    void Awake()
    {
        Pool pool = Pools.pool;

        rootSystems = new RootSystems(pool);

		pool.CreateEntity().AddCamera(Camera.main).AddGameObject(Camera.main.gameObject.transform.parent.gameObject).AddCameraSettings(CameraDampTime, CameraScreenEdgeBuffer, CameraMinSize);

        for(int i=0; i<Tanks.Length; i++)
        {
            TankSetupInfo info = Tanks[i];
            pool.CreateEntity().IsPlayer(true).AddId(i + 1).AddColour(info.PlayerColor).AddWins(0);
			CreateTank(pool, i+1, info);
		}

        pool.CreateEntity().IsRound(true).AddRoundNumber(0).AddRoundPhase(RoundPhase.Start).AddRoundMessage(MessageText).AddRequiredToWin(NumRoundsToWin);      
    }

	void CreateTank(Pool pool, int id, TankSetupInfo info)
	{
		pool.CreateEntity()
			.IsTank(true)
			.AddId(id)
			.AddColour(info.PlayerColor)
			.AddStartPosition(info.SpawnPoint.position)
			.AddStartRotation(info.SpawnPoint.rotation)
			.AddFireChargeSpeed((info.FireLaunchForceMax - info.FireLaunchForceMin) / info.FireLaunchTime)
			.AddFireChargeTime(info.FireLaunchTime)
			.AddFireLaunchForce(info.FireLaunchForceMin, info.FireLaunchForceMin, info.FireLaunchForceMax)
			.AddHealth(info.StartingHealth, info.StartingHealth)
			.AddMoveSpeed(info.MoveSpeed)
			.AddTurnSpeed(info.TurnSpeed);
	}

    void Start()
	{
		try {
			rootSystems.Initialize();
		} catch (Exception e) {
			HandleError(e);
		}
	}

	void Update()
	{
		if(!running){
			return;
		}

		try {
			rootSystems.Execute();
		} catch (Exception e) {
			HandleError(e);
		}
	}

	void HandleError(Exception e)
	{
		running = false;
        Debug.LogError(e.StackTrace);
	}
}