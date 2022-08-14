using Entities.AbstractEnvironmentObjects;
using UnityEngine;

namespace Generate.AbstractGenerate
{
    public abstract class FollowerSerialGeneratorObjects<T>:SerialGeneratorObjects<T> where T:SerialEnvironmentObject
    {
        [Header("Target object settings")]
        [SerializeField] private float _spawnDistanceFromTarget;
        [SerializeField] private Transform _target;
        
        protected virtual void Update()
        {
            if ((OrientDirection(_target.transform.position) -
                 OrientDirection(_activeObjectsOnScene[_activeObjectsOnScene.Count - 1].End.position)).magnitude <= _spawnDistanceFromTarget)
                SerialSpawnObjects();
        }
    }
}