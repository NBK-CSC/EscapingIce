using System;
using UnityEngine;
using UnityEngine.UI;

namespace Counters
{
    public class CounterPoints
    {
        private Vector3 _startPosition;
        private Text _label;
        private int _points=0;

        public CounterPoints(Text label, Vector3 startPosition)
        {
            _label = label;
            _startPosition = startPosition;
        }

        public void UpdatePoint(Vector3 currentPosition)
        { 
            IncreasePoints((int)(_startPosition - currentPosition).z);
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
