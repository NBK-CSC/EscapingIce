using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _panelPauseMenu;

        public void Reset()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
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
            SceneManager.LoadScene(0);
        }
    }
}