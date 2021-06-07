using UnityEngine;
using UnityEngine.SceneManagement;

namespace UrfuProject
{
    public class Winning : MonoBehaviour
    {
        private LevelManager levelManager;
        private Quest currentQuest;

        public void Start()
        {

        }

        public void SetQuest(Quest quest)
        {
            currentQuest = quest;
        }

        public void Exit()
        {
            //TODO Save
            Application.Quit();
        }


        public void Continue()
        {
            //TODO Save
            GameStatistic.AddQuestPoint(currentQuest.Level);
            GameStatistic.AddLaboratoryPoints(GameStatistic.Sciences.Math);
            GameStatistic.Money += currentQuest.Reward;
            Cursor.lockState = CursorLockMode.Locked;
            gameObject.SetActive(false);
            Time.timeScale = 1;
            Debug.Log($"Money {GameStatistic.Money}");
            Debug.Log($"Science {GameStatistic.SciencePoints}");
            GameStatistic.OnStatsChanged?.Invoke();
            //LevelManager.OnQuestCompleted();
        }
    }
}