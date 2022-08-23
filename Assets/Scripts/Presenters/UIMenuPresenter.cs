using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Presenters
{
    public class UIMenuPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameObject _othersPanel;

        private IMenuButtonView _menuButtonView;

        public void Init(IMenuButtonView menuButtonView)
        {
            _menuButtonView = menuButtonView;
        }

        public void Enable()
        {
            _menuButtonView.SettingsOpened += OpenSettings;
            _menuButtonView.OfSettingsGetOut += CloseSettings;
            _menuButtonView.OthersOpened += OpenOthers;
            _menuButtonView.OfOthersGetOut += CloseOthers;
        }

        public void Disable()
        {
            _menuButtonView.SettingsOpened -= OpenSettings;
            _menuButtonView.OfSettingsGetOut -= CloseSettings;
            _menuButtonView.OthersOpened -= OpenOthers;
            _menuButtonView.OfOthersGetOut -= CloseOthers;
        }
        
        private void OpenSettings()
        {
            _settingsPanel.SetActive(true);
        }
        
        private void CloseSettings()
        {
            _settingsPanel.SetActive(false);
        }
        
        private void OpenOthers()
        {
            _othersPanel.SetActive(true);
        }
        
        private void CloseOthers()
        {
            _othersPanel.SetActive(false);
        }
    }
}