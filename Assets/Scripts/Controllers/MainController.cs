using UnityEngine;
using UnityEngine.Events;

public class MainController:MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private CameraFollower _camera;
    [SerializeField] private Transform _cameraStartPoint;
    [SerializeField] private IcesController _icesController;

    public event UnityAction FollowingChanged;

    private void OnEnable()
    {
        _icesController.IceHasChanged += ChangeFollowing;
    }

    private void OnDisable()
    {
        _icesController.IceHasChanged -= ChangeFollowing;
    }

    private void ChangeFollowing(Ice ice)
    {
        _camera.transform.position = _cameraStartPoint.position;
        _camera.TargetTransform = ice.transform;
        FollowingChanged?.Invoke();
    }
}
