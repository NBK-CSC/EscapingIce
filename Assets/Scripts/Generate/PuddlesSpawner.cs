using System.Collections;
using System.Collections.Generic;
using Models;
using ObjectPool;
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
        [SerializeField] private float _timeSpawnAfterSelfBreak;
        [SerializeField] private float _timeSpawnAfterBreak;
        
        private PoolMono<Puddle> _poolPuddles;
        private Dictionary<BreakState, float> _timeDelaySpawn;

        private void Start()
        {
            _poolPuddles = new PoolMono<Puddle>(_amountPuddle, _puddlePrefab, _puddleContainer);
            _timeDelaySpawn = new Dictionary<BreakState, float>
            {
                { BreakState.Crash, _timeSpawnAfterBreak },
                { BreakState.Melt, _timeSpawnAfterBreak },
                { BreakState.SelfBreak, _timeSpawnAfterSelfBreak }
            };
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
            if (breakState!=BreakState.Fell)
                StartCoroutine(DelaySpawn(_timeDelaySpawn[breakState]));
        }

        private IEnumerator DelaySpawn(float time)
        {
            yield return new WaitForSeconds(time);
            if (_poolPuddles.TryGetObject(out var puddle))
            {
                var position = _ice.transform.position;
                puddle.transform.position = new Vector3(position.x, _offsetY, position.z);
            }
        }
    }
}
