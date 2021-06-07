using UnityEngine;
using UnityEngine.SceneManagement;

namespace UrfuProject
{
    public class MainMenu : MonoBehaviour
    {
        // Start is called before the first frame update
       

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