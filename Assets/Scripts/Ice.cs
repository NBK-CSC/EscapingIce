using System;
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
    
    public event UnityAction<Vector3> BecamePuddle;

    private void Start()
    {
        _rb = transform.GetComponent<Rigidbody>();
        _boxCollider = transform.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (!TryBecomePuddle())
        {
            Move();
            Melt();
        }
        else
        {
            BecomePuddle();
            Destroy(transform.gameObject);
        }
    }

    private void BecomePuddle()
    {
        Instantiate(_puddlePrefab, _rb.position, _rb.rotation);
    }

    private void Move()
    {
        _rb.MovePosition(_rb.position+_speed*Vector3.back);
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
