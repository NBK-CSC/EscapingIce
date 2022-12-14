using System.Collections;
using Models;
using Models.–°hangeable;
using UnityEngine;
using UnityEngine.Events;
using Views;
using Views.Game;

namespace Presenters
{
    public class IcePresenter : MonoBehaviour
    {
        [SerializeField] private float _timeDelaySpawn;
        [SerializeField] private Ice _ice;

        private IGameButtonView _gameButtonView;
        private Breaker _breaker;

        public event UnityAction IceBroken;
        
        public void Init(IGameButtonView gameButtonView)
        {
            _gameButtonView = gameButtonView;
            _breaker = new Breaker(_ice, _gameButtonView);
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