using UnityEngine;
using UnityEngine.SceneManagement;

namespace UrfuProject
{
    public class MainMenu : MonoBehaviour
    {
        public void Quit()
        {
            Debug.Log("Выход");
            Application.Quit();
        }

        public void StartGame()
        {
            SceneManager.LoadScene((int)GameStatistic.Scenes.MainScene);
            QuestManager.GetNewQuests();
        }

    }
}