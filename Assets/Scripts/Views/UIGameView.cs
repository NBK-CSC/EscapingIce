using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class UIGameView : MonoBehaviour, IView
    {
        [Header("1 layer UI")]
        [SerializeField] private Button _breakButton;
        [SerializeField] private Button _pauseButton;

        [Header("2 layer UI")]
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitSceneButton;
        [Header("3 layer UI")]
        [SerializeField] private Button _exitSettingsButton;
        
        public event Action Broken;
        public event Action Paused;
        public event Action Resumed;
        public event Action SettingsOpened;
        public event Action OfSettingsGetOut;
        public event Action OfSceneGetOut;
        
        private void OnEnable()
        {
            _breakButton.onClick.AddListener(Break);
            _pauseButton.onClick.AddListener(Pause);
            _resumeButton.onClick.AddListener(Resume);
            _settingsButton.onClick.AddListener(OpenSettings);
            _exitSceneButton.onClick.AddListener(ExitToMenu);
            _exitSettingsButton.onClick.AddListener(ExitToPause);
        }

        private void OnDisable()
        {
            _breakButton.onClick.RemoveListener(Break);
            _pauseButton.onClick.RemoveListener(Pause);
            _resumeButton.onClick.RemoveListener(Resume);
            _settingsButton.onClick.RemoveListener(OpenSettings);
            _exitSceneButton.onClick.RemoveListener(ExitToMenu);
            _exitSettingsButton.onClick.RemoveListener(ExitToPause);
        }
        
        private void Break()
        {
            Broken?.Invoke();
        }

        private void Pause()
        {
            Paused?.Invoke();
        }

        private void Resume()
        {
            Resumed?.Invoke();
        }

        private void OpenSettings()
        {
            SettingsOpened?.Invoke();
        }

        private void ExitToMenu()
        {
            OfSceneGetOut?.Invoke();
        }

        private void ExitToPause()
        {
            OfSettingsGetOut?.Invoke();
        }
    }
}