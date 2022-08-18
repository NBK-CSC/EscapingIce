using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(PlayGame);
            _exitButton.onClick.AddListener(Exit);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(PlayGame);
            _exitButton.onClick.RemoveListener(Exit);
        }

        private void PlayGame()
        {
            SceneSwitcher.SwitchToGameScene();
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}
