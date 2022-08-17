using UnityEngine;

namespace Entities
{
    public class Puddle : MonoBehaviour
    {
        [SerializeField] private float _acceleration;

        public float Acceleration => _acceleration;
    }
}
