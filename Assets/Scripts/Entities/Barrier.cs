using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlayAudio()
    {
        _audioSource.Play();
    }

}
