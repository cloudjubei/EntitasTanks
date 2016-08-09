using System;
using UnityEngine;

[Serializable]
public class TankSetupInfo
{
    public Color PlayerColor;
    public Transform SpawnPoint;
    public float StartingHealth = 100f;

    public float FireLaunchTime = 0.75f;
    public float FireLaunchForceMin = 15f;
    public float FireLaunchForceMax = 30f;

    public float MoveSpeed = 12f;
    public float TurnSpeed = 180f;
}
