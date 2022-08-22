using Models;
using UnityEngine;

namespace Audios
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioClip _breakAudio;
        
        private AudioSource _audioSource;
        private Ice _ice;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _ice = GetComponent<Ice>();
        }

        private void OnEnable()
        {
            _ice.Broken += Break;
        }

        private void OnDisable()
        {
            _ice.Broken -= Break;
        }

        private void Break(BreakState breakState)
        {
            _audioSource.PlayOneShot(_breakAudio);
        }
    }
}
