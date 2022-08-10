using System.Collections.Generic;
using Entries;
using UnityEngine;

namespace Generate
{
    public abstract class SerialGeneratorObjects<T>: GeneratorObjects <T> where T: SerialEnvironmentObject
    {
        [SerializeField] private int _maxNumberObjectsOnScene;
        [SerializeField] private T startEnvironmentObject;
        
        protected List<T> _activeObjectsOnScene = new List<T>();

        private void Start()
        {
            Init();
            _activeObjectsOnScene.Add(startEnvironmentObject);
        }
        
        private void DisablePreviousObject(int numberItemDisable)
        {
            _activeObjectsOnScene[numberItemDisable].gameObject.SetActive(false);
            _activeObjectsOnScene.RemoveAt(numberItemDisable);
        }

        protected void SerialSpawnObjects(int numberItemDisable=1)
        {
            var _endLastSubject = _activeObjectsOnScene[_activeObjectsOnScene.Count - 1].End;
            var newObject = SpawnObject(_endLastSubject.position, _endLastSubject.rotation);
            if (newObject != null)
                _activeObjectsOnScene.Add(newObject);
            if (_activeObjectsOnScene.Count > _maxNumberObjectsOnScene)
                DisablePreviousObject(numberItemDisable);
        }

        protected override T SpawnObject(Vector3 position, Quaternion rotation)
        {
            var newObject=base.SpawnObject(position, rotation);
            newObject.transform.position -= newObject.Begin.localPosition;
            return newObject;
        }
        
        protected void Reset()
        {
            int count = _activeObjectsOnScene.Count;
            for (int i=1;i<count;i++)
                DisablePreviousObject(1);
        }
    }
}