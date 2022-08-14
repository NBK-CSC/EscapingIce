using System;
using System.Collections.Generic;
using Entities.AbstractEnvironmentObjects;
using UnityEngine;
using Random = System.Random;

namespace Generate.AbstractGenerate
{
    public abstract class LocalGeneratorObjects<T>:GeneratorObjects<T> where T:LocalEnvironmentObject
    {
        [SerializeField] private Transform _generateCenter;
        [SerializeField] private T _startEnvironmentObject;
        [Header("Limit settings")]
        [SerializeField] private float _leftLimitDistance;
        [SerializeField] private float _rightLimitDistance;
        [SerializeField] private Vector3 _leftPointDirection;
        [SerializeField] private Vector3 _rightPointDirection;
        
        protected List<T> _activeObjectsOnScene = new List<T>();
        
        protected override void Start()
        {
            base.Start();
            _activeObjectsOnScene.Add(_startEnvironmentObject);
            _rightPointDirection.Normalize();
            _leftPointDirection.Normalize();
        }

        protected void LocalSpawnObjects(Vector3 position)
        {
            var randomDistance = (float)new Random().Next(-(int)_leftLimitDistance*1000,(int)_rightLimitDistance*1000)/1000;
            var spawnPosition = position + Math.Abs(randomDistance) * (randomDistance >= 0 ?_rightPointDirection:_leftPointDirection);
            _activeObjectsOnScene.Add(SpawnObject(spawnPosition,Quaternion.identity));
        }
    }
}