using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class Ice : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _frictionForce;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _meltingFactor;
    [SerializeField] private Transform _particleContainer;
    
    private Vector3 _sizeBoxCollider;
    private Vector3 _centerBoxCollider;
    private Vector3 _particleContainerPosition;
    private Rigidbody _rb;
    private BoxCollider _boxCollider;
    
    public event UnityAction BecamePuddle;
    
    private void Start()
    {
        _rb = transform.GetComponent<Rigidbody>();
        _boxCollider = transform.GetComponent<BoxCollider>();
        _sizeBoxCollider = _boxCollider.size;
        _centerBoxCollider = _boxCollider.center;
        _particleContainerPosition = _particleContainer.localPosition;
    }
    
    private void FixedUpdate()
    {
        if (TryBecomePuddle())
            Stop();
        else
        {
            Move(Input.GetAxis("Horizontal"));
            Melt();
        }
    }

    private bool TryBecomePuddle()
    {
        return _boxCollider.size.y <= 0f;
    }
    

    private void Stop()
    {
        BecamePuddle?.Invoke();
    }

    private void Move(float dir)
    {
        Vector3 dirMovement = new Vector3(dir, 0, 1);
        _rb.MovePosition(_rb.position+_speed*dirMovement);
        ReduceFastSpeed();
    }

    private void ReduceFastSpeed()
    {
        if (_speed > _minSpeed)
            _speed -= _frictionForce;
    }
    
    private void Melt()
    {
        var boxColliderCenter = _boxCollider.center;
        var boxColliderSize = _boxCollider.size;
        var particleContainerPosition = _particleContainer.position;
        
        _boxCollider.size = new Vector3(boxColliderSize.x, boxColliderSize.y - _meltingFactor, boxColliderSize.z);
        _boxCollider.center = new Vector3(boxColliderCenter.x, boxColliderCenter.y + _meltingFactor/2, boxColliderCenter.z);
        _particleContainer.position=new Vector3(particleContainerPosition.x, particleContainerPosition.y + _meltingFactor, particleContainerPosition.z);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Puddle>(out var puddle))
            _speed = puddle.Acceleration;
    }

    public void Disactivate()
    {
        _boxCollider.size = _sizeBoxCollider;
        _boxCollider.center = _centerBoxCollider;
        _particleContainer.localPosition = _particleContainerPosition;
        gameObject.SetActive(false);
    }
}
