using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Presenters
{
    public class UIPresenter : MonoBehaviour
    {
        [SerializeField] private IcePresenter _icePresenter;
        [SerializeField] private Text _numberAttemptsLabel;
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _settingsPanel;

        private IView _view;
        private int _numberAttempts;

        public void Init(IView view, int numberAttempts)
        {
            _view = view;
            _numberAttempts = numberAttempts;
            PrintNumberOfAttempts(_numberAttempts);
        }

        public void Enable()
        {
            _icePresenter.IceBroken += DecreaseNumberIce;
            _view.Paused += Pause;
            _view.Resumed += Resume;
            _view.SettingsOpened += OpenSettings;
            _view.OfSettingsGetOut += ExitSettings;
        }

        public void Disable()
        {
            _icePresenter.IceBroken -= DecreaseNumberIce;
            _view.Paused -= Pause;
            _view.Resumed -= Resume;
            _view.SettingsOpened -= OpenSettings;
            _view.OfSettingsGetOut -= ExitSettings;
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

        private void DecreaseNumberIce()
        {
            _numberAttempts -= 1;
            if (_numberAttempts <= 0)
                Debug.Log("Game over");
            PrintNumberOfAttempts(_numberAttempts);
        }
        
        private void PrintNumberOfAttempts(int number)
        {
            _numberAttemptsLabel.text = $"x{number}";
        }
    }
}