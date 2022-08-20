using System.Collections;
using Entities;
using UnityEngine;
using UnityEngine.Events;

namespace Controllers
{
    public class IceController : MonoBehaviour
    {
        [SerializeField] private float _timeDelayBreak;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Ice _ice;
        
        public event UnityAction IceBroken;
        public event UnityAction<Vector3> OnSurfaceIceBroken;

        private void OnEnable()
        {
            _ice.Broken += AppearIce;
        }

        private void OnDisable()
        {
            _ice.Broken -= AppearIce;
        }

        private IEnumerator DelayBroke()
        {
            yield return new WaitForSeconds(_timeDelayBreak);
            IceBroken?.Invoke();
            if (_ice.IsOnSurface)
                OnSurfaceIceBroken?.Invoke(_ice.transform.position);
            _ice.transform.position = _startPoint.position;
        }

        private void AppearIce()
        {
            StartCoroutine(DelayBroke());
        }
    }
}