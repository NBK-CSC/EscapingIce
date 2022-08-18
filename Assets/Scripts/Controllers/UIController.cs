using System;
using Entities;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Text _label;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private Button _dieButton;
        [SerializeField] private Ice _ice;

        private void OnEnable()
        {
            _dieButton.onClick.AddListener(MakeIceBroke);
        }

        private void OnDisable()
        {
            _dieButton.onClick.RemoveListener(MakeIceBroke);
        }

        private void MakeIceBroke()
        {
            _ice.Broke();
        }
        
        public void PrintNumberOfAttempts(int number)
        {
            _label.text = $"x{number}";
        }
        
        public void GameOver()
        {
            _pauseMenu.Pause();
        }
    }
}