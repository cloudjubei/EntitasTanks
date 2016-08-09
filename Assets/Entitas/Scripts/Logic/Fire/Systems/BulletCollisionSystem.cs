using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BulletCollisionSystem : ASystem, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
    public IMatcher ensureComponents
    {
        get
        {
			return Matcher.AllOf(Matcher.Shell, Matcher.Collision, Matcher.GameObject);
        }
    }

    public IMatcher excludeComponents
    {
        get
        {
            return Matcher.AnyOf(Matcher.ShouldBeDestroyed, Matcher.Destroyed);
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Collision.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (Entity e in entities)
        {
			Vector3 position = e.GetPosition();
			float explosionRadius = e.collision.explosionRadius;
            float maxDamage = e.collision.maxDamage;
            float explosionForce = e.collision.explosionForce;
            LayerMask tankMask = e.collision.tankMask;

            Collider[] colliders = Physics.OverlapSphere(position, explosionRadius, tankMask);

            foreach(Collider collider in colliders)
            {
                Rigidbody targetRigidbody = collider.GetComponent<Rigidbody>();

                if (targetRigidbody != null && targetRigidbody.gameObject.HasEntity())
                {
                    Hit(targetRigidbody.gameObject.GetEntity(), position, explosionRadius, maxDamage, explosionForce);
                }
            }

            e.isShouldBeDestroyed = true;
        }
    }

    void Hit(Entity e, Vector3 position, float explosionRadius, float maxDamage, float explosionForce)
    {
        e.AddHit(position, explosionRadius, maxDamage, explosionForce);
    }
}