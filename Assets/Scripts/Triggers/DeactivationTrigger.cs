using Entities;
using UnityEngine;

public class DeactivationTrigger:MonoBehaviour
{
    [SerializeField] private GameObject _boards;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Ice>(out var ice))
            _boards.SetActive(false);
    }
}