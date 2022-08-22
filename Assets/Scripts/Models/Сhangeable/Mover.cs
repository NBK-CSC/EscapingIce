using UnityEngine;

namespace Models.Сhangeable
{
    [RequireComponent(typeof(Rigidbody))]
    public class Mover: MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _frictionFactor;
        [SerializeField] private float _minSpeed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = transform.GetComponent<Rigidbody>();
        }
        
        private void ReduceFastSpeed(float slowdown)
        {
            if (_speed > _minSpeed)
                _speed -= slowdown;
        }
        
        public void Move(Vector3 dirMovement)
        {
            _rigidbody.MovePosition(_rigidbody.position + _speed * dirMovement);
            ReduceFastSpeed(_frictionFactor);
        }

        public void SpeedUp(float speed)
        {
            if (speed > _speed)
                _speed = speed;
        }
    }
}