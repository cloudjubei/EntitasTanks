using UnityEngine;

public class TankAudioBehaviour : MonoBehaviour
{
    public AudioSource MovementAudio;
    public AudioClip MovementIdleClip;
    public AudioClip MovementDrivingClip;
    public float MovementPitchRange = 0.2f;
    public float MovementOriginalPitch;

    public AudioSource ShotAudio;
    public AudioClip ShotChargingClip;
    public AudioClip ShotFireClip;
    
    void Start()
    {
        MovementOriginalPitch = MovementAudio.pitch;
    }

    #region Public

    public void PlayMovementIdle()
    {
        if (MovementAudio.clip == MovementDrivingClip)
        {
            PlayMovement(MovementIdleClip);
        }
    }

    public void PlayerMovementDriving()
    {
        if (MovementAudio.clip == MovementIdleClip)
        {
            PlayMovement(MovementDrivingClip);
        }
    }

    public void PlayShotCharging()
    {
        ShotAudio.clip = ShotChargingClip;
        ShotAudio.Play();
    }

    public void PlayShotFire()
    {
        ShotAudio.clip = ShotFireClip;
        ShotAudio.Play();
    }

    #endregion

    #region Internal

    void PlayMovement(AudioClip clip)
    {
        MovementAudio.clip = clip;
        MovementAudio.pitch = Random.Range(MovementOriginalPitch - MovementPitchRange, MovementOriginalPitch + MovementPitchRange);
        MovementAudio.Play();
    }

    #endregion
}