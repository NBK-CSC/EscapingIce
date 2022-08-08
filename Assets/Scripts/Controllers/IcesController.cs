using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IcesController:MonoBehaviour
{
    [SerializeField] private int _amountIce;
    [SerializeField] private int _maxNumberIce;
    [SerializeField] private Ice _icePrefab;
    [SerializeField] private Transform _iceContainer;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioBroken;
    [SerializeField] private Text _label;
    [SerializeField] private MainController _mainController;
    
    
    
    private int _numberIce;
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
        _numberIce = _maxNumberIce;
        _poolIces = new PoolMono<Ice>(_amountIce, _icePrefab, _iceContainer);
        ChangeIceAndSpawn();
        DecreaseNumberIce(0);
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
            DecreaseNumberIce(1);
            _audioSource.PlayOneShot(_audioBroken,1f);
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
    
    private void DecreaseNumberIce(int count)
    {
        _numberIce -= count;
        if (_numberIce<=0)
            _mainController.Reset();
        _label.text = $"x{_numberIce}";
    }
}
