using Entitas;
using UnityEngine;

public class HitComponent : IComponent
{
    public Vector3 hitPosition;
    public float explosionRadius;
    public float damage;
    public float explosionForce;
}