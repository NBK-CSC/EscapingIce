using System.Collections;
using BreakStates;
using Models;
using ObjectPool;
using Presenters;
using UnityEngine;

namespace Generate
{
    public class PuddlesSpawner:MonoBehaviour
    {
        [SerializeField] private int _amountPuddle;
        [SerializeField] private Puddle _puddlePrefab;
        [SerializeField] private Transform _puddleContainer;
        [SerializeField] private Ice _ice;
        [SerializeField] private float _offsetY;
        [SerializeField] private float _timeRespawn;
        
        private PoolMono<Puddle> _poolPuddles;

        private void Start()
        {
            _poolPuddles = new PoolMono<Puddle>(_amountPuddle, _puddlePrefab, _puddleContainer);
        }

        private void OnEnable()
        {
            _ice.Broken += SpawnPuddle;
        } 
        private void OnDisable()
        {
            _ice.Broken += SpawnPuddle;
        } 

        private void SpawnPuddle(BreakState breakState)
        {
            if (breakState==BreakState.Crashed || breakState==BreakState.Melt || breakState==BreakState.SelfBreak)
                StartCoroutine(DelaySpawn());
        }

        private IEnumerator DelaySpawn()
        {
            yield return new WaitForSeconds(_timeRespawn);
            if (_poolPuddles.TryGetObject(out var puddle))
            {
                var position = _ice.transform.position;
                puddle.transform.position = new Vector3(position.x, _offsetY, position.z);
            }
        }
    }
}
