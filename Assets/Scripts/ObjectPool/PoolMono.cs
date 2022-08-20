using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ObjectPool
{
    public class PoolMono<T> where T: MonoBehaviour
    {
        public T Prefab { get; }
        public bool AutoExpand { get; set; }
        public Transform Container { get; }
        private List<T> _pool;

        public PoolMono(int count, T prefab)
        {
            Prefab = prefab;
            Container = null;
        
            CreatePool(count);
        }
    
        public PoolMono(int count, T prefab, Transform container)
        {
            Prefab = prefab;
            Container = container;
        
            CreatePool(count);
        }


        private void CreatePool(int count)
        {
            _pool = new List<T>();
            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault=false)
        {
            var createdObject = Object.Instantiate(Prefab, Container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }

        public bool TryGetObject(out T gameObject)
        {
            foreach (var mono in _pool)
                if (!mono.gameObject.activeInHierarchy)
                {
                    mono.gameObject.SetActive(true);
                    gameObject = mono;
                    return true;
                }
            gameObject = null;
            return false;
        }

        public T GetFreeObject()
        {
            if (TryGetObject(out var element))
                return element;
            if (AutoExpand)
                return CreateObject();
            throw new Exception($"There is no free element in pool of type {typeof(T)}");
        }
    }
}
