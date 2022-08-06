using UnityEngine;

public class SurfaceGenerator : MonoBehaviour
{
    [SerializeField] private int _amountSurface;
    [SerializeField] private int _startCountSurface;
    [SerializeField] private Surface _surfacePrefab;
    [SerializeField] private Transform _surfaceContainer;
    [SerializeField] private Vector3 _blockLength;
    [SerializeField] private Transform _startPoint;

    private Vector3 _generatePosition;
    private PoolMono<Surface> _pool;
    private GameObject _currentSurface;
    private GameObject _previousSurface;
    
    private void Start()
    {
        _pool = new PoolMono<Surface>(_amountSurface, _surfacePrefab, _surfaceContainer);
        GenerateSurface(_startCountSurface,_startPoint.position);
    }
    
    private void GenerateSurface(int count, Vector3 point)
    {
        _generatePosition = point;
        for (int i = 0; i < count; i++)
            if (_pool.TryGetObject(out var surface))    
            {
                surface.gameObject.SetActive(true);
                surface.transform.position = _generatePosition;
                _generatePosition += _blockLength;
            }
    }
}
