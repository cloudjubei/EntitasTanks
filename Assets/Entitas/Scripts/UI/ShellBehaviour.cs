using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{
    public LayerMask TankMask;
    public ParticleSystem ExplosionParticles;
    public AudioSource ExplosionAudio;

    public float ExplosionRadius = 5;
    public float MaxDamage = 100;
    public float ExplosionForce = 1000;
    
    public void ShowDeath()
    {
        ExplosionParticles.transform.parent = null;
        ExplosionParticles.Play();

        ExplosionAudio.Play();

        Destroy(ExplosionParticles.gameObject, ExplosionParticles.duration);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!gameObject.GetEntity().hasCollision)
        {
            gameObject.GetEntity().AddCollision(other, TankMask, ExplosionRadius, MaxDamage, ExplosionForce);
        }
    }
}