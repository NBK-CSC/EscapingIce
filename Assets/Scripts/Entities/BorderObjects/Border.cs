using UnityEngine;

namespace Entities.BorderObjects
{
    public class Border : MonoBehaviour, IBorder
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Ice>(out var ice))
                ice.Break();
        }
    }
}
