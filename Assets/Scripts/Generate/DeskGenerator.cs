using System;
using UnityEngine;

namespace Generate
{
    public class DeskGenerator : SerialGeneratorObjects<Desk>
    {
        [SerializeField] private Ice _target;

        private void OnEnable()
        {
            _target.Broken += Reset;
        }

        private void OnDisable()
        {
            _target.Broken -= Reset;
        }

        private void Update()
        {
            if (_target.transform.position.z-_activeObjectsOnScene[_activeObjectsOnScene.Count - 1].End.position.z+10>0)
                SerialSpawnObjects();
        }
    }
}