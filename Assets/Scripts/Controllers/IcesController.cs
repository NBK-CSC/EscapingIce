using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IcesController:MonoBehaviour
{
    [SerializeField] private int _amountIce;
    [SerializeField] private Ice _icePrefab;
    [SerializeField] private Transform _iceContainer;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Button _button;
    
    private Ice _currentIceObject;
    private PoolMono<Ice> _poolIces;
    
    public event UnityAction<Ice> IceHasChanged;
    public event UnityAction<Ice> IceDeactivatied;

    private void OnEnable()
    {
        _button.onClick.AddListener(MakeIceMelt);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(MakeIceMelt);
    }

    private void Start()
    {
        _poolIces = new PoolMono<Ice>(_amountIce, _icePrefab, _iceContainer);
        ChangeIceAndSpawn();
    }

    private void MakeIceMelt()
    {
        _currentIceObject.MeltAway();
    }

    private void ChangeIceAndSpawn()
    {
        if (_currentIceObject != null)
            IceDeactivatied?.Invoke(_currentIceObject);
        ChangeIce();
    }

    private void ChangeIce()
    {
        if (_currentIceObject != null)
        {
            _currentIceObject.Melted -= ChangeIceAndSpawn;
            _currentIceObject.Diactivated -= ChangeIce;
        }
        if (_poolIces.TryGetObject(out _currentIceObject))
        {
            _currentIceObject.Melted += ChangeIceAndSpawn;
            _currentIceObject.Diactivated += ChangeIce;
            _currentIceObject.transform.position = _startPoint.position;
            IceHasChanged?.Invoke(_currentIceObject);
        }
    }
}
