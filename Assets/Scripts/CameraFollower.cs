using UnityEngine;

public class CameraFollower : Follower
{
    public Transform TargetTransform
    {
        get => _targetTransform;
        set => _targetTransform = value;
    }

    private void Start()
    {
        _offset = transform.position - _targetTransform.position;
    }

    private void FixedUpdate()=>Move(Time.fixedDeltaTime);
}