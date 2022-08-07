using UnityEngine;

public class DeactivationZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Ice>(out var ice))
            ice.MeltAway();
    }
}
