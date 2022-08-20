using Entities;
using UnityEngine;

namespace Controllers
{
    public class PuddlesController:MonoBehaviour
    {
        [SerializeField] private int _amountPuddle;
        [SerializeField] private Puddle _puddlePrefab;
        [SerializeField] private Transform _puddleContainer;
        [SerializeField] private IceController _iceController;
        [SerializeField] private float _offcetY;
        
        private PoolMono<Puddle> _poolPuddles;

        private void Start()
        {
            _poolPuddles = new PoolMono<Puddle>(_amountPuddle, _puddlePrefab, _puddleContainer);
        }

        private void OnEnable()
        {
            _iceController.OnSurfaceIceBroken += SpawnPuddle;
        } 
        private void OnDisable()
        {
            _iceController.OnSurfaceIceBroken += SpawnPuddle;
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
