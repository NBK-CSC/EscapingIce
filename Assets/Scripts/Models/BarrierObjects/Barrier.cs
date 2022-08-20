using Models.AbstractEnvironmentObjects;
using UnityEngine;

namespace Models.BarrierObjects
{
    public abstract class Barrier : LocalEnvironmentObject, IBarrier
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Ice>(out var ice))
                ice.Break();
        }
    }
}
