using Entities;
using UnityEngine;

namespace Controllers
{
    public class PuddlesController:MonoBehaviour
    {
        [SerializeField] private int _amountPuddle;
        [SerializeField] private Puddle _puddlePrefab;
        [SerializeField] private Transform _puddleContainer;
        [SerializeField] private Ice _ice;
        [SerializeField] private float _offcetY;
        
        private PoolMono<Puddle> _poolPuddles;

        private void Start()
        {
            _poolPuddles = new PoolMono<Puddle>(_amountPuddle, _puddlePrefab, _puddleContainer);
        }

        private void OnEnable() => _ice.Broken += SpawnPuddle;
        private void OnDisable() => _ice.Broken -= SpawnPuddle;

        private void SpawnPuddle()
        {
            if (_poolPuddles.TryGetObject(out var puddle))
            {
                var icePosition = _ice.transform.position;
                puddle.transform.position = new Vector3(icePosition.x, icePosition.y+_offcetY, icePosition.z);
            }
        }   
    }
}
