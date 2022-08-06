using UnityEngine;

public class MainController:MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private CameraFollower _camera;
    [SerializeField] private Transform _cameraStartPoint;
    [SerializeField] private IcesController _icesController;

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
    }
}
