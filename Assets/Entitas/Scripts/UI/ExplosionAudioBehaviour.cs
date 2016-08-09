using UnityEngine;

public class ExplosionAudioBehaviour : MonoBehaviour
{
    public AudioSource ExplosionAudio;

    public void PlayExplosion()
    {
        ExplosionAudio.Play();
    }
}