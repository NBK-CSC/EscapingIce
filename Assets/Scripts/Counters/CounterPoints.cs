using System;
using UnityEngine;
using UnityEngine.UI;

namespace Counters
{
    public class CounterPoints : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Text _label;
    
        private int _points=0;
        private Vector3 _lastPosition;

        private void Start()
        {
            _lastPosition = _camera.transform.position;
        }

        private void Update()
        { 
            IncreasePoints((int)(_lastPosition - _camera.transform.position).z);
        }

        private void IncreasePoints(int count)
        {
            if (Math.Abs(count) < _points)
                return;
            _points = Math.Abs(count);
            _label.text = _points.ToString();
        }
    }
}
