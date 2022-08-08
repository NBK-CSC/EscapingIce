using UnityEngine;
using Random = System.Random;

public class BarriersGenerator : MonoBehaviour
{
    [SerializeField] private Barrier _forkPrefab;
    [SerializeField] private Barrier _bearPrefab;
    [SerializeField] private Barrier _glassPrefab;
    [SerializeField] private int _amountBarrier;
    [SerializeField] private Vector3 _positionBetweenSpawn;
    [SerializeField] private float _distanceBetweenBarriers;
    [SerializeField] private Transform _startDistanceSpawn;
    [SerializeField] private Transform _rightLimitPos;
    [SerializeField] private Transform _leftLimitPos;

    [SerializeField] private Transform _barrierContainer;
    [SerializeField] private Camera _camera;
    
    private PoolMono<Barrier> _poolFork;
    private PoolMono<Barrier> _poolBear;
    private PoolMono<Barrier> _poolGlass;
    private Vector3 _lastBarrierPosition;

    private void Awake()
    {
        _poolFork = new PoolMono<Barrier>(_amountBarrier, _forkPrefab, _barrierContainer);
        _poolBear = new PoolMono<Barrier>(_amountBarrier, _bearPrefab, _barrierContainer);
        _poolGlass = new PoolMono<Barrier>(_amountBarrier, _glassPrefab, _barrierContainer);
        _lastBarrierPosition = _startDistanceSpawn.position;
    }

    private void Update()
    {
        if (transform.position.z-_lastBarrierPosition.z > _distanceBetweenBarriers)
            GenerateBarrier(1,transform.position, false);
    }

    private void GenerateBarrier(int count, Vector3 point, bool isAlreadyIndented = true)
    {
        _lastBarrierPosition = isAlreadyIndented ? point : point + _positionBetweenSpawn;
        for (int i = 0; i < count; i++)
        {
            int random = new Random().Next(1, 4);
            switch (random)
            {
                case 1:
                    SetBarrier(_poolFork.GetFreeObject());
                    break;
                case 2:
                    SetBarrier(_poolBear.GetFreeObject());
                    break;
                case 3:
                    SetBarrier(_poolGlass.GetFreeObject());
                    break;
            }

        }
}

    private void SetBarrier(Barrier barrier)
    {
        barrier.gameObject.SetActive(true);
        int random = new Random().Next((int)_leftLimitPos.position.x*100, (int)_rightLimitPos.position.x*100);
        _lastBarrierPosition.x=(float)random/100;
        barrier.transform.position = _lastBarrierPosition;
        barrier.PlayAudio();
    }
}
