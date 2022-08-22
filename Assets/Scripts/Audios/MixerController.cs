using UnityEngine;
using UnityEngine.Audio;

namespace Audios
{
    public class MixerController : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;

        public void SetVolume(float volume)
        {
            _audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        }

    }
}