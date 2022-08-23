using System;
using Counters;
using UnityEditor;
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

        private IGameView _gameView;
        private CounterPoints _counterPoints;
        private CounterAttempts _counterAttempts;
        
        public void Init(IGameView gameView, IcePresenter icePresenter, int numberAttempts)
        {
            _gameView = gameView;
            _counterPoints = new CounterPoints(_labelPoints, _cameraTransform.position);
            _counterAttempts = new CounterAttempts(icePresenter, _labelAttempts, numberAttempts);
        }

        public void Enable()
        {
            _gameView.Paused += Pause;
            _gameView.Played += Resume;
            _gameView.SettingsOpened += OpenSettings;
            _gameView.OfSettingsGetOut += ExitSettings;
            _counterAttempts.Enable();
            _counterAttempts.AttemptsOver += OpenGameOverPanel;
        }

        public void Disable()
        {
            _gameView.Paused -= Pause;
            _gameView.Played -= Resume;
            _gameView.SettingsOpened -= OpenSettings;
            _gameView.OfSettingsGetOut -= ExitSettings;
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