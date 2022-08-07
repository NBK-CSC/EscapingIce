using System.Collections.Generic;
using UnityEngine;

public class DeskGenerator : MonoBehaviour
{
    [SerializeField] private int _amountSurface;
    [SerializeField] private int _startCountDesk;
    [SerializeField] private Desk _deskPrefab;
    [SerializeField] private Transform _deskContainer;
    [SerializeField] private Vector3 _deskLength;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private MainController _mainController;
    
    private Vector3 _generatePosition;
    private PoolMono<Desk> _pool;
    private List<Desk> _deskOnScenes;

    private void OnEnable() => _mainController.FollowingChanged += Reset;
    private void OnDisable() => _mainController.FollowingChanged += Reset;
    
    private void Awake()
    {
        _pool = new PoolMono<Desk>(_amountSurface, _deskPrefab, _deskContainer);
        _deskOnScenes = new List<Desk>();
    }

    private void Reset()
    {
        GenerateDesk(_startCountDesk,_startPoint.position);
    }

    private void GenerateDesk(int count, Vector3 point,bool isAlreadyIndented=true)
    {
        _generatePosition = isAlreadyIndented? point:point+_deskLength;
        if (IsPlaceTakenByDesk())
            return;
        for (int i = 0; i < count; i++)
            if (_pool.TryGetObject(out var desk))
            {
                SetDesk(desk);
                _generatePosition += _deskLength;
            }
    }

    private void SetDesk(Desk desk)
    {
        desk.gameObject.SetActive(true);
        desk.transform.position = _generatePosition;
        desk.GenerateTrigger.CollisionEntered += GenerateDesk;
        _deskOnScenes.Add(desk);
    }

    private bool IsPlaceTakenByDesk()
    {
        var desk = _deskOnScenes.Find(desk => desk.transform.position == _generatePosition);
        return desk != null && desk.gameObject.activeInHierarchy;
    }
}
