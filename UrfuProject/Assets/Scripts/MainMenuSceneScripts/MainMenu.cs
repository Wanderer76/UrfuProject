using UnityEngine;

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
            GameStatistic.isGameNew = false;
            LevelManager.LoadLevel(Scenes.MainScene);
            QuestManager.GetNewQuests();
        }

    }
}