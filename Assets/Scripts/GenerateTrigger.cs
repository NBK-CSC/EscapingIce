using UnityEngine;
using UnityEngine.Events;

public class GenerateTrigger:MonoBehaviour
{
    [SerializeField] private Transform _spawnTransform;
    
    public event UnityAction<int,Vector3,bool> CollisionEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Ice>(out var ice))
            CollisionEntered?.Invoke(1,_spawnTransform.position,false);
    }
}