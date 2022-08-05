using UnityEngine;

public class MainController:MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private CameraFollower _camera;
    [SerializeField] private int _amountIce;
    [SerializeField] private Ice _icePrefab;
    [SerializeField] private Transform _iceContainer;

    private Ice _currentIceObject;
    
    private PoolMono<Ice> _poolIces;

    private void Start()    
    {
        _poolIces = new PoolMono<Ice>(_amountIce, _icePrefab, _iceContainer);
        Reset();
    }

    private void Reset()
    {
        if (_currentIceObject!=null)
            _currentIceObject.BecamePuddle -= Reset;
        if (_poolIces.TryGetObject(out _currentIceObject))
        {
            _currentIceObject.BecamePuddle += Reset;
            _currentIceObject.transform.position = _startPoint.position;
            _camera.TargetTransform = _currentIceObject.transform;
        }
}
}
