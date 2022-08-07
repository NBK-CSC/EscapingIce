using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class Ice : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _frictionForce;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _meltingFactor;
    [SerializeField] private float _distanceCheckGround;
    [SerializeField] private ParticleSystem _particleTraceMelt;
    [SerializeField] private ParticleSystem _particleSpray;
    [SerializeField] private Transform _rayTransform1;
    [SerializeField] private Transform _rayTransform2;
    [SerializeField] private Transform _particleContainer;
    
    private Vector3 _sizeBoxCollider;
    private Vector3 _centerBoxCollider;
    private Vector3 _particleContainerPosition;
    private Rigidbody _rb;
    private BoxCollider _boxCollider;
    
    public event UnityAction Melted;
    public event UnityAction Diactivated;
    
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
            MeltAway();
        else
        {
            Move(Input.GetAxis("Horizontal"));
            Melt();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Puddle>(out var puddle))
            _speed = puddle.Acceleration;
    }
    
    private bool TryBecomePuddle()
    {
        return _boxCollider.size.y <= 0f;
    }
    
    private void Move(float dir)
    {
        Vector3 dirMovement = new Vector3(dir, 0, 1);
        _rb.MovePosition(_rb.position+_speed*dirMovement);
        PlayParticles();
        ReduceFastSpeed();
    }

    private void PlayParticles()
    {
        if (!CanMelted())
            return;
        _particleTraceMelt.Play();
        _particleSpray.Play();
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
    
    private void SetDefault()
    {
        _boxCollider.size = _sizeBoxCollider;
        _boxCollider.center = _centerBoxCollider;
        _particleContainer.localPosition = _particleContainerPosition;
        gameObject.SetActive(false);
    }

    public bool CanMelted()
    {
        Ray ray1 = new Ray(_rayTransform1.position, -_rayTransform1.up);
        Ray ray2 = new Ray(_rayTransform2.position, -_rayTransform2.up);
        return Physics.Raycast(ray1, out RaycastHit hit1, _distanceCheckGround) ||
               Physics.Raycast(ray2, out RaycastHit hit2, _distanceCheckGround);
    }

    public void MeltAway()
    {
        Melted?.Invoke();
        SetDefault();
    }
    
    public void Diactivate()
    {
        Diactivated?.Invoke();
        SetDefault();
    }
}
