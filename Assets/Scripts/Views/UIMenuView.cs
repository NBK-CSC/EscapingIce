using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class UIMenuView : MonoBehaviour, IMenuButtonView
    {
        [Header("1 layer UI")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _othersButton;
        [SerializeField] private Button _exitButton;

        [Header("2 layer UI")]
        [SerializeField] private Button _backSettingsButton;
        [SerializeField] private Button _backOthersButton;
        
        public event Action Played;
        public event Action Exited;
        public event Action SettingsOpened;
        public event Action OfSettingsGetOut;
        public event Action OthersOpened;
        public event Action OfOthersGetOut;
        
        private void OnEnable()
        {
            _playButton.onClick.AddListener(Play);
            _exitButton.onClick.AddListener(Exit);
            _settingsButton.onClick.AddListener(OpenSettings);
            _backSettingsButton.onClick.AddListener(BackSettings);
            _othersButton.onClick.AddListener(OpenOthers);
            _backOthersButton.onClick.AddListener(BackOthers);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(Play);
            _exitButton.onClick.RemoveListener(Exit);
            _settingsButton.onClick.RemoveListener(OpenSettings);
            _backSettingsButton.onClick.RemoveListener(BackSettings);
            _othersButton.onClick.RemoveListener(OpenOthers);
            _backOthersButton.onClick.RemoveListener(BackOthers);
        }
        
        private void Play()
        {
            Played?.Invoke();
        }

        private void Exit()
        {
            Exited?.Invoke();
        }
        
        private void OpenSettings()
        {
            SettingsOpened?.Invoke();
        }

        private void BackSettings()
        {
            OfSettingsGetOut?.Invoke();
        }

        private void OpenOthers()
        {
            OthersOpened?.Invoke();
        }
        
        private void BackOthers()
        {
            OfOthersGetOut?.Invoke();
        }
    }
}