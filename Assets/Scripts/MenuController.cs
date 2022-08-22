using Presenters;
using UI;
using UnityEngine;
using Views;

public class MenuController : MonoBehaviour
{
    [SerializeField] private UIMenuView _uiMenuView;
    [SerializeField] private UIMenuPresenter _uiMenuPresenter;
    
    private SceneSwitcher _sceneSwitcher;
    
    private void Awake()
    {
        _sceneSwitcher = new SceneSwitcher();
        _uiMenuPresenter.Init(_uiMenuView);
    }

    private void OnEnable()
    {
        _uiMenuView.Played += Play;
        _uiMenuView.Exited += Exit;
        _uiMenuPresenter.Enable();
    }
        
    private void OnDisable()
    {
        _uiMenuView.Played -= Play;
        _uiMenuView.Exited -= Exit;
        _uiMenuPresenter.Disable();
    }

    private void Play()
    {
        _sceneSwitcher.SwitchToGameScene();
    }
    
    private void Exit()
    {
        Application.Quit();
    }
}