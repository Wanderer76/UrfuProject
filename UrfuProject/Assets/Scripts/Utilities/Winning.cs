using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UrfuProject
{
    public class Winning : MonoBehaviour
    {
        private Quest currentQuest;
        private bool isWin;
        public Text statusText;

        public void SetQuest(Quest quest)
        {
            currentQuest = quest;
            Debug.Log($"Quest type = {currentQuest.Level}");
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void SetWinStatus()
        {
            isWin = true;
            statusText.text = "Успешно завершенно";
        }
        public void SetFailStatus()
        {
            isWin = false;
            statusText.text = "Неудача";
        }

        public void Continue()
        {
            Time.timeScale = 1;
            if (isWin)
            {
                GameStatistic.AddQuestPoint(currentQuest.Level);
                GameStatistic.AddLaboratoryPoints(GameStatistic.Sciences.Math);
                GameStatistic.Money += currentQuest.Reward;
            }
            Cursor.lockState = CursorLockMode.Locked;
            gameObject.SetActive(false);
            QuestManager.QuestCompleted(currentQuest);
            GameStatistic.OnStatsChanged?.Invoke();
            LevelManager.OnQuestCompleted();
        }
    }
}