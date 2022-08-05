using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class Ice : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _meltingFactor;
    [SerializeField] private GameObject _puddlePrefab;
    
    private Rigidbody _rb;
    private BoxCollider _boxCollider;
    
    public event UnityAction BecamePuddle;

    private void Start()
    {
        _rb = transform.GetComponent<Rigidbody>();
        _boxCollider = transform.GetComponent<BoxCollider>();
    }

    private void OnEnable()=> BecamePuddle += BecomePuddle;
    private void OnDisable()=>BecamePuddle -= BecomePuddle;


    private void FixedUpdate()
    {
        var inputHorizontal = Input.GetAxis("Horizontal");
        if (!TryBecomePuddle())
        {
            Move(inputHorizontal);
            Melt();
        }
        else
        {
            //gameObject.SetActive(false);
            BecamePuddle?.Invoke();
        }
    }

    private void BecomePuddle()
    {
        Debug.Log("test");
        var puddlePosition = new Vector3(_rb.position.x, 3.2f, _rb.position.z);
        Instantiate(_puddlePrefab, puddlePosition, _rb.rotation);
        BecamePuddle -= BecomePuddle;
    }

    private void Move(float dir)
    {
        Vector3 dirMovement = new Vector3(-dir, 0, -1);
        _rb.MovePosition(_rb.position+_speed*dirMovement);
    }

    private bool TryBecomePuddle()
    {
        return _boxCollider.size.y <= 0f;
    }

    private void Melt()
    {
        var boxColliderCenter = _boxCollider.center;
        var boxColliderSize = _boxCollider.size;
        
        _boxCollider.size = new Vector3(boxColliderSize.x, boxColliderSize.y - _meltingFactor, boxColliderSize.z);
        _boxCollider.center = new Vector3(boxColliderCenter.x, boxColliderCenter.y + _meltingFactor/2, boxColliderCenter.z);
    }
}
