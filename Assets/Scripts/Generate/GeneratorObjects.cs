using UnityEngine;

namespace Generate
{
    public abstract class GeneratorObjects <T> : MonoBehaviour where T: MonoBehaviour
    {
        [Header("Object settings")]
        [SerializeField] private int _numberObject;
        [SerializeField] private T _prefabObject;
        [Header("Storage")]
        [SerializeField] private Transform _containerObjects;

        private PoolMono<T> _pool;

        protected void Init()
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
    }
}