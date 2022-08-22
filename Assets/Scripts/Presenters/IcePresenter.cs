using System.Collections;
using Models;
using Models.Сhangeable;
using UnityEngine;
using UnityEngine.Events;
using Views;

namespace Presenters
{
    public class IcePresenter : MonoBehaviour
    {
        [SerializeField] private float _timeDelaySpawn;
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
            _ice.Broken += SpawnIce;
            _breaker.Enable();
        }

        public void Disable()
        {
            _ice.Broken -= SpawnIce;
            _breaker.Disable();
        }

        private void SpawnIce(BreakState breakState)
        {
            StartCoroutine(DelaySpawnIce());
        }
        
        private IEnumerator DelaySpawnIce()
        {
            yield return new WaitForSeconds(_timeDelaySpawn);
            IceBroken?.Invoke();
            _ice.SetDefault();
        }
    }
}