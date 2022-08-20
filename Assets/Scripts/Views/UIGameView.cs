using System;
using Controllers;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class UIGameView : MonoBehaviour
    {
        [SerializeField] private Text _labelNumberAttempts;
        [SerializeField] private GameObject _panelPauseMenu;
        [SerializeField] private Button _dieButton;
        [SerializeField] private BreakController _breakController;

        private PauseMenu _pauseMenu;
        
        private void OnEnable()
        {
            _dieButton.onClick.AddListener(MakeBreak);
        }

        private void OnDisable()
        {
            _dieButton.onClick.RemoveListener(MakeBreak);
        }

        private void Start()
        {
            _pauseMenu = new PauseMenu(_panelPauseMenu);
        }

        public void PrintNumberOfAttempts(int number)
        {
            _labelNumberAttempts.text = $"x{number}";
        }
        
        public void GameOver()
        {
            _pauseMenu.Pause();
        }

        private void MakeBreak()
        {
            _breakController.MakeBreakIce();
        }
    }
}