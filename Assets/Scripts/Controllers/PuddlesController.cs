using UnityEngine;

namespace Controllers
{
    public class PuddlesController:MonoBehaviour
    {
        [SerializeField] private int _amountPuddle;
        [SerializeField] private Puddle _puddlePrefab;
        [SerializeField] private Transform _puddleContainer;
        [SerializeField] private IcesController _icesController;
        [SerializeField] private float _offcetY=4.1f;
        
        private PoolMono<Puddle> _poolPuddles;

        private void Start()
        {
            _poolPuddles = new PoolMono<Puddle>(_amountPuddle, _puddlePrefab, _puddleContainer);
        }

        private void OnEnable() => _icesController.IceBroke += SpawnPuddle;
        private void OnDisable() => _icesController.IceBroke -= SpawnPuddle;

        private void SpawnPuddle(Ice ice)
        {
            if (_poolPuddles.TryGetObject(out var puddle))
            {
                var icePosition = ice.transform.position;
                puddle.transform.position = new Vector3(icePosition.x, _offcetY, icePosition.z);
            }
        }   
    }
}
