using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public static class SceneSwitcher
    {
        public static void SwitchToGameScene()
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }
        
        public static void SwitchToMenuScene()
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
    }
}