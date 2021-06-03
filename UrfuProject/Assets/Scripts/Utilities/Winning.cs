using UnityEngine;
using UnityEngine.SceneManagement;

namespace UrfuProject
{
    public class Winning : MonoBehaviour
    {

        LevelManager levelManager;
        int CurrentQuest;

        public void Start()
        {
            CurrentQuest = PlayerPrefs.GetInt("CurrentQuestIndex", 0);
        }

        public void Exit()
        {
            //TODO Save
            Application.Quit();
        }


        public void Continue()
        {
            //TODO Save
            //manager.QuestCompleted();
            PlayerPrefs.SetInt("CompletedQuest", CurrentQuest);
            //QuestManager.OnQuestCompleted.Invoke(0);
            LevelManager.OnQuestCompleted();
        }
    }
}