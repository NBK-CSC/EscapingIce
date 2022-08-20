using System.Collections;
using Entities;
using Models;
using UnityEngine;
using UnityEngine.Events;
using Views;

namespace Presenters
{
    public class IcePresenter : MonoBehaviour
    {
        [SerializeField] private float _timeDelayBreak;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Ice _ice;

        private IView _view;
        
        public event UnityAction IceBroken;
        public event UnityAction<Vector3> OnSurfaceIceBroken;

        public void Init(IView view)
        {
            _view = view;
        }

        public void Enable()
        {
            _ice.Broken += AppearIce;
            _view.Broken += AppearIce;
        }

        public void Disable()
        {
            _ice.Broken -= AppearIce;
            _view.Broken -= AppearIce;
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