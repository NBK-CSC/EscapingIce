using System;
using UnityEngine;

namespace Generate
{
    public class DeskGenerator : SerialGeneratorObjects<Desk>
    {

        [SerializeField] private Transform _target;

        public Transform Target
        {
            get => _target;
            set => _target = value;
        }

        private void Update()
        {
            if (Target.position.z-_activeObjectsOnScene[_activeObjectsOnScene.Count - 1].End.position.z+10>0)
            {
                SerialSpawnObjects();
            }
        }
    }
}