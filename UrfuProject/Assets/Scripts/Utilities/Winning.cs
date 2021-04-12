using UnityEngine;
using UnityEngine.SceneManagement;

namespace UrfuProject
{
    public class Winning : MonoBehaviour
    {

        QuestManager manager;
        LevelManager levelManager;

        public void Exit()
        {
            //TODO Save
            Application.Quit();
        }


        public void Continue()
        {
            //TODO Save
            //manager.QuestCompleted();
            QuestManager.OnQuestCompleted.Invoke(0);
            LevelManager.OnQuestCompleted();
        }
    }
}