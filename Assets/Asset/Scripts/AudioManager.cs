using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingAudio;
    [SerializeField] [Range(0, 1)] float shootingVolume = 1f;

    public void PlayShootingSFX()
    {
        AudioSource.PlayClipAtPoint(shootingAudio, Camera.main.transform.position, shootingVolume);
    }


    [Header("TakeDame SFX")]
    [SerializeField] AudioClip takeDameAudio;
    [SerializeField] [Range(0, 1)] float takeDameVolume = 1f;

    public void PlayTakeDameSFX()
    {
        AudioSource.PlayClipAtPoint(takeDameAudio, Camera.main.transform.position, takeDameVolume);
    }
}
