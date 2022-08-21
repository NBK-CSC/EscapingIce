using Models.AbstractEnvironmentObjects;
using UnityEngine;

namespace Generate.AbstractGenerate
{
    public abstract class FollowerLocalGeneratorObjects<T>:LocalGeneratorObjects<T> where T:LocalEnvironmentObject
    {
        [Header("Target object settings")]
        [SerializeField] private float _spawnDistanceFromTarget;
        [SerializeField] private float _spawnDistanceBetweenBarrier;
        [SerializeField] private Transform _target;
        
        protected virtual void Update()
        {
            if (_target.position.z - _occupiedPlaces[_occupiedPlaces.Count-1].z >= _spawnDistanceBetweenBarrier)
                LocalSpawnObjects(OrientDirection(_target.position  + GenerateDirection * _spawnDistanceFromTarget));
        }
    }
}