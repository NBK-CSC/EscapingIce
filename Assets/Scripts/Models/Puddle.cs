using UnityEngine;

namespace Models
{
    public class Puddle : MonoBehaviour
    {
        [SerializeField] private float _acceleration;

        public float Acceleration => _acceleration;
    }
}
