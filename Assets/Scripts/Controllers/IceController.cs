using Entities;
using UnityEngine;

namespace Controllers
{
    public class IceController : MonoBehaviour
    {
        [SerializeField] private Ice _ice;
        [SerializeField] private Transform _startPoint;

        private void OnEnable()
        {
            _ice.Broken += AppearIce;
        }

        private void OnDisable()
        {
            _ice.Broken -= AppearIce;
        }
        
        private void AppearIce()
        {
            _ice.gameObject.SetActive(true);
            _ice.transform.position = _startPoint.position;
        }
    }
}