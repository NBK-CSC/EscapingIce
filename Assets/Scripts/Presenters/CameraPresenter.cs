using UnityEngine;

namespace Presenters
{
    public class CameraPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _cameraStartPoint;
        [SerializeField] private IcePresenter icePresenter;
        
        private void OnEnable()
        {
            icePresenter.IceBroken += SetIcePositionInDefault;
        }

        private void OnDisable()
        {
            icePresenter.IceBroken -= SetIcePositionInDefault;
        }
        
        private void SetIcePositionInDefault()
        {
            _camera.transform.position = _cameraStartPoint.position;
        }
    }
}