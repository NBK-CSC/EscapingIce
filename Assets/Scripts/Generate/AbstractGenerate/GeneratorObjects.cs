using ObjectPool;
using UnityEngine;

namespace Generate.AbstractGenerate
{
    public abstract class GeneratorObjects <T> : MonoBehaviour where T: MonoBehaviour
    {
        [Header("Object settings")]
        [SerializeField] private int _numberObject;
        [SerializeField] private T _prefabObject;
        [Header("Storage")]
        [SerializeField] private Transform _containerObjects;
        [Header("Generate settings")]
        [SerializeField] private Vector3 _generateDirection;

        protected Vector3 GenerateDirection => _generateDirection;

        private PoolMono<T> _pool;

        protected virtual void Start()
        {
            _generateDirection.Normalize();
            Init();
        }

        private void Init()
        {
            _pool = new PoolMono<T>(_numberObject, _prefabObject, _containerObjects);
        }

        protected virtual T SpawnObject(Vector3 position, Quaternion rotation)
        {
            if (_pool.TryGetObject(out var objectT))
            {
                var objectTransform = objectT.transform;
                objectTransform.position = position;
                objectTransform.rotation = rotation;
                return objectT;
            }
            return null;
        }
        
        protected Vector3 OrientDirection(Vector3 dir)
        {
            return OrientDirection(dir,_generateDirection);
        }
        
        protected Vector3 OrientDirection(Vector3 dir1,Vector3 dir2)
        {
            return new Vector3(dir1.x*dir2.x,dir1.y*dir2.y,dir1.z*dir2.z);
        }
    }
}