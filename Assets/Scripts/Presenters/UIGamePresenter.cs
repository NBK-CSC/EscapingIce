using Counters;
using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Presenters
{
    public class UIGamePresenter : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        [Header("Labels")]
        [SerializeField] private Text _labelPoints;
        [SerializeField] private Text _labelAttempts;
        [Header("Panels")]
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameObject _gameOverPanel;

        private IGameButtonView _gameButtonView;
        private CounterPoints _counterPoints;
        private CounterAttempts _counterAttempts;
        
        public CounterAttempts CounterAttempts() => _counterAttempts;
        
        public void Init(IGameButtonView gameButtonView, IcePresenter icePresenter, int numberAttempts)
        {
            _gameButtonView = gameButtonView;
            _counterPoints = new CounterPoints(_labelPoints, _cameraTransform.position);
            _counterAttempts = new CounterAttempts(icePresenter, _labelAttempts, numberAttempts);
        }

        public void Enable()
        {
            _gameButtonView.Paused += Pause;
            _gameButtonView.Played += Resume;
            _gameButtonView.SettingsOpened += OpenSettings;
            _gameButtonView.OfSettingsGetOut += ExitSettings;
            _counterAttempts.Enable();
            _counterAttempts.AttemptsOver += OpenGameOverPanel;
        }

        public void Disable()
        {
            _gameButtonView.Paused -= Pause;
            _gameButtonView.Played -= Resume;
            _gameButtonView.SettingsOpened -= OpenSettings;
            _gameButtonView.OfSettingsGetOut -= ExitSettings;
            _counterAttempts.Disable();
            _counterAttempts.AttemptsOver -= OpenGameOverPanel;
        }
        
        private void Update()
        {
            _counterPoints.UpdatePoint(_cameraTransform.position);
        }

        private void Pause()
        {
            _pausePanel.SetActive(true);
        }

        private void Resume()
        {
            _pausePanel.SetActive(false);
        }

        private void OpenSettings()
        {
            _settingsPanel.SetActive(true);
        }


        private void ExitSettings()
        {
            _settingsPanel.SetActive(false);
        }

        private void OpenGameOverPanel()
        {
            _gameOverPanel.SetActive(true);
        }
    }
}