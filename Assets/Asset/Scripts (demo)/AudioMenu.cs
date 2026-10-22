using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField][Range(0, 1)] float volume;

    private void Start() => AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
}
