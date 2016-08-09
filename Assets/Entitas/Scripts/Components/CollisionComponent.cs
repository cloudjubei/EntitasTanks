using Entitas;
using UnityEngine;

public class CollisionComponent : IComponent
{
    public Collider other;
    public LayerMask tankMask;
    public float explosionRadius;
    public float maxDamage;
    public float explosionForce;
}