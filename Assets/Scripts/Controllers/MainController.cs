using UnityEngine;
using UnityEngine.Events;

namespace Controllers
{
    public class MainController:MonoBehaviour
    {
        [SerializeField] private CameraFollower _camera;
        [SerializeField] private Transform _cameraStartPoint;
        [SerializeField] private IcesController _icesController;
        [SerializeField] private GameObject _panelResetMenu;

        public event UnityAction FollowingChanged;

        private void OnEnable()
        {
            _icesController.IceAppeared += ChangeFollowing;
        }

        private void OnDisable()
        {
            _icesController.IceAppeared -= ChangeFollowing;
        }

        private void ChangeFollowing(Ice ice)
        {
            _camera.transform.position = _cameraStartPoint.position;
            _camera.TargetTransform = ice.transform;
            FollowingChanged?.Invoke();
        }

        public void Reset()
        {
            Time.timeScale = 0f;
            _panelResetMenu.SetActive(true);
        }
    }
}
