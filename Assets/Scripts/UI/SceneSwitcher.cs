using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneSwitcher
    {
        public void SwitchToGameScene()
        {
            SceneManager.LoadScene(1);
        }
        
        public void SwitchToMenuScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}