using UnityEngine;

public abstract class Follower : MonoBehaviour
{
    [SerializeField] private float _smoothing;
    [SerializeField] protected Transform _targetTransform;
    [SerializeField] protected Vector3 _offset;
    
    protected void Move(float deltaTime)
    {
        if (_targetTransform == null) return;
        transform.position =
            Vector3.Lerp(transform.position, _targetTransform.position + _offset, deltaTime * _smoothing);
    }
}
