using UnityEngine;

namespace UI
{
    public class PauseMenu
    {
        private GameObject _panelPauseMenu;

        public PauseMenu(GameObject panelPauseMenu)
        {
            _panelPauseMenu = panelPauseMenu;
        }

        public void Reset()
        {
            SceneSwitcher.SwitchToGameScene();
        }
    
        public void Pause()
        {
            _panelPauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            _panelPauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Exit()
        {
            SceneSwitcher.SwitchToMenuScene();
        }
    }
}