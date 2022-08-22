using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Presenters
{
    public class UIMenuPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameObject _othersPanel;

        private IMenuView _menuView;

        public void Init(IMenuView menuView)
        {
            _menuView = menuView;
        }

        public void Enable()
        {
            _menuView.SettingsOpened += OpenSettings;
            _menuView.OfSettingsGetOut += CloseSettings;
            _menuView.OthersOpened += OpenOthers;
            _menuView.OfOthersGetOut += CloseOthers;
        }

        public void Disable()
        {
            _menuView.SettingsOpened -= OpenSettings;
            _menuView.OfSettingsGetOut -= CloseSettings;
            _menuView.OthersOpened -= OpenOthers;
            _menuView.OfOthersGetOut -= CloseOthers;
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