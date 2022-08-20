using Entities;
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
        [SerializeField] private IcePresenter icePresenter;
        [SerializeField] private float _offcetY;
        
        private PoolMono<Puddle> _poolPuddles;

        private void Start()
        {
            _poolPuddles = new PoolMono<Puddle>(_amountPuddle, _puddlePrefab, _puddleContainer);
        }

        private void OnEnable()
        {
            icePresenter.OnSurfaceIceBroken += SpawnPuddle;
        } 
        private void OnDisable()
        {
            icePresenter.OnSurfaceIceBroken += SpawnPuddle;
        } 

        private void SpawnPuddle(Vector3 position)
        {
            if (_poolPuddles.TryGetObject(out var puddle))
            {
                puddle.transform.position = new Vector3(position.x, _offcetY, position.z);
            }
        }   
    }
}
