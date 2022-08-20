using Presenters;
using UnityEngine;
using Views;

public class MainController : MonoBehaviour
{
    [SerializeField] private int _numberAttempts;
    [SerializeField] private IcePresenter icePresenter;
    [SerializeField] private UIPresenter uiPresenter;
    [SerializeField] private UIGameView _uiGameView;
        
    private TimePresenter _timePresenter;

    private void Awake()
    {
        _timePresenter = new TimePresenter(_uiGameView);
        uiPresenter.Init(_uiGameView, _numberAttempts);
        icePresenter.Init(_uiGameView);
    }

    private void OnEnable()
    {
        _timePresenter.Enable();
        uiPresenter.Enable();
        icePresenter.Enable();
    }
        
    private void OnDisable()
    {
        _timePresenter.Disable();
        uiPresenter.Disable();
        icePresenter.Disable();
    }
}