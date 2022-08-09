using UnityEngine;

namespace Entries
{
    public abstract class SerialEnvironmentObject : EnvironmentObject
    {
        [SerializeField] private Transform _begin;
        [SerializeField] private Transform _end;

        public Transform Begin => _begin;
        public Transform End => _end;
    }
}