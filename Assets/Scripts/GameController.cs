using Presenters;
using UI;
using UnityEngine;
using Views;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _numberAttempts;
    [SerializeField] private IcePresenter _icePresenter;
    [SerializeField] private UIGamePresenter _uiGamePresenter;
    [SerializeField] private UIGameView _uiGameView;
    
    private TimePresenter _timePresenter;
    private SceneSwitcher _sceneSwitcher;

    private void Awake()
    {
        _timePresenter = new TimePresenter(_uiGameView);
        _sceneSwitcher = new SceneSwitcher();
        _uiGamePresenter.Init(_uiGameView, _icePresenter, _numberAttempts);
        _icePresenter.Init(_uiGameView);
    }

    private void OnEnable()
    {
        _timePresenter.Enable();
        _uiGamePresenter.Enable();
        _icePresenter.Enable();
        _uiGameView.Exited += Exit;
    }
        
    private void OnDisable()
    {
        _timePresenter.Disable();
        _uiGamePresenter.Disable();
        _icePresenter.Disable();
        _uiGameView.Exited -= Exit;
    }

    private void EndGame()
    {
    }

    private void Exit()
    {
        _sceneSwitcher.SwitchToMenuScene();
    }
}