using Models.Сhangeable;
using UnityEngine;

namespace Models
{
    public class Puddle : MonoBehaviour
    {
        [SerializeField] private float _acceleration;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Mover>(out var mover))
                mover.SpeedUp(_acceleration);
        }
    }
}
