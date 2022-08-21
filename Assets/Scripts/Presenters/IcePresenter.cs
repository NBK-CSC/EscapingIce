using System.Collections;
using BreakStates;
using Models;
using UnityEngine;
using UnityEngine.Events;
using Views;

namespace Presenters
{
    public class IcePresenter : MonoBehaviour
    {
        [SerializeField] private float _timeDelayBreak;
        [SerializeField] private Ice _ice;

        private IView _view;
        private Breaker _breaker;

        public event UnityAction IceBroken;
        
        public void Init(IView view)
        {
            _view = view;
            _breaker = new Breaker(_ice, _view);
        }

        public void Enable()
        {
            _ice.Broken += AppearIce;
            _breaker.Enable();
        }

        public void Disable()
        {
            _ice.Broken -= AppearIce;
            _breaker.Disable();
        }

        private IEnumerator DelayBroke()
        {
            yield return new WaitForSeconds(_timeDelayBreak);
            IceBroken?.Invoke();
            _ice.SetDefault();
        }

        private void AppearIce(BreakState breakState)
        {
            StartCoroutine(DelayBroke());
        }
    }
}