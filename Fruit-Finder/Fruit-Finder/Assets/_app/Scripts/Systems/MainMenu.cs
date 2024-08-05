using UnityEngine;
using UnityEngine.SceneManagement;

namespace _app.Scripts.Systems
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadSceneAsync("Intro");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}