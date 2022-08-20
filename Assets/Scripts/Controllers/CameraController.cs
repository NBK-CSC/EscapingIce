using UnityEngine;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _cameraStartPoint;
        [SerializeField] private IceController _iceController;
        
        private void OnEnable()
        {
            _iceController.IceBroken += SetIcePositionInDefault;
        }

        private void OnDisable()
        {
            _iceController.IceBroken -= SetIcePositionInDefault;
        }
        
        private void SetIcePositionInDefault()
        {
            _camera.transform.position = _cameraStartPoint.position;
        }
    }
}