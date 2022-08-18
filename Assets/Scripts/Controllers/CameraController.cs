using Entities;
using UnityEngine;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _cameraStartPoint;
        [SerializeField] private Ice _ice;
        
        private void OnEnable()
        {
            _ice.Broken += SetIcePositionInDefault;
        }

        private void OnDisable()
        {
            _ice.Broken -= SetIcePositionInDefault;
        }
        
        private void SetIcePositionInDefault()
        {
            _camera.transform.position = _cameraStartPoint.position;
        }
    }
}