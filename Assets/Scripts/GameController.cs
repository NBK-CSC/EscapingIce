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
    private GameView _gameView;

    private void Awake()
    {
        _timePresenter = new TimePresenter(_uiGameView);
        _sceneSwitcher = new SceneSwitcher();
        _uiGamePresenter.Init(_uiGameView, _icePresenter, _numberAttempts);
        _icePresenter.Init(_uiGameView);
        _gameView = new GameView(_uiGamePresenter.CounterAttempts());
    }

    private void OnEnable()
    {
        _timePresenter.Enable();
        _uiGamePresenter.Enable();
        _icePresenter.Enable();
        _gameView.Enable();
        _uiGameView.Exited += Exit;
        _gameView.GameOver += EndGame;
    }
        
    private void OnDisable()
    {
        _timePresenter.Disable();
        _uiGamePresenter.Disable();
        _icePresenter.Disable();
        _gameView.Disable();
        _uiGameView.Exited -= Exit;
        _gameView.GameOver -= EndGame;
    }

    private void EndGame()
    {
        
    }

    private void Exit()
    {
        _sceneSwitcher.SwitchToMenuScene();
    }
}