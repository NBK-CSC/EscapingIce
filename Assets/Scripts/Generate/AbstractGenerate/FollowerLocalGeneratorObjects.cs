using Entities.AbstractEnvironmentObjects;
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
            if ((OrientDirection(_target.position) -
                 OrientDirection(_activeObjectsOnScene[_activeObjectsOnScene.Count - 1].transform.position)).magnitude >= _spawnDistanceBetweenBarrier)
                LocalSpawnObjects(_target.position  + GenerateDirection*_spawnDistanceFromTarget);
        }
    }
}