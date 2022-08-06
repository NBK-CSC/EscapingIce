using UnityEngine;
using UnityEngine.Events;

public class TriggerGeneratePoint:MonoBehaviour
{
    public event UnityAction CollisionEntered; 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ice>(out var ice))
            CollisionEntered?.Invoke();
    }
}
