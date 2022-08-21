using Presenters;
using UnityEngine;
using Views;

public class MainController : MonoBehaviour
{
    [SerializeField] private int _numberAttempts;
    [SerializeField] private IcePresenter _icePresenter;
    [SerializeField] private UIPresenter _uiPresenter;
    [SerializeField] private UIGameView _uiGameView;
        
    private TimePresenter _timePresenter;

    private void Awake()
    {
        _timePresenter = new TimePresenter(_uiGameView);
        _uiPresenter.Init(_uiGameView, _numberAttempts);
        _icePresenter.Init(_uiGameView);
    }

    private void OnEnable()
    {
        _timePresenter.Enable();
        _uiPresenter.Enable();
        _icePresenter.Enable();
    }
        
    private void OnDisable()
    {
        _timePresenter.Disable();
        _uiPresenter.Disable();
        _icePresenter.Disable();
    }
}