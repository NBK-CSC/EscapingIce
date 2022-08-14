using Entities.AbstractEnvironmentObjects;
using UnityEngine;

namespace Entities.BarrierObjects
{
    public class Barrier : LocalEnvironmentObject
    {
        [SerializeField] private AudioSource _audioSource;

        public void PlayAudio()
        {
            _audioSource.Play();
        }

    }
}
