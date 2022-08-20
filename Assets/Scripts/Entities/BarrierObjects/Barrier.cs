using Entities.AbstractEnvironmentObjects;
using UnityEngine;

namespace Entities.BarrierObjects
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
