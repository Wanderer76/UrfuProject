using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UrfuProject
{
    public class UIScript : MonoBehaviour
    {

        private const string ScienceText = "Научные очки";
        private const string MoneyText = "Деньги";

        public GameObject exitPanel;
        public GameObject questsPanel;
        private GameObject actionElement;

        public GameObject notificationImage;

        public Text sciencePointsText;
        public Text moneyText;

        private void Awake()
        {
            actionElement = GameObject.Find("ActionsElement");
            UpdateStatisticUI();
        }
        private void Start()
        {
            GameStatistic.OnStatsChanged.AddListener(UpdateStatisticUI);
            QuestManager.OnQuestCountChanged.AddListener(() => {
                notificationImage.SetActive(true);
            });
        }
        private void UpdateStatisticUI()
        {
            sciencePointsText.text = $"{ScienceText}:{GameStatistic.SciencePoints}";
            moneyText.text = $"{MoneyText}:{GameStatistic.Money}";
        }

        public void OnQuitClicked()
        {
            ActivatePanel(exitPanel);
        }

        public void Continue()
        {
           DeactivatePanel(exitPanel);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene((int)GameStatistic.Scenes.Menu);
        }

        public void ShowQuestsTable()
        {
            notificationImage.SetActive(false);
            ActivatePanel(questsPanel);
        }
        public void HideQuestsTable()
        {
            DeactivatePanel(questsPanel);
        }

        public void Quit()
        {
            Application.Quit();
        }

        private void ActivatePanel(GameObject showed)
        {
            showed.SetActive(true);
            actionElement.SetActive(false);
        }
        private void DeactivatePanel(GameObject showed)
        {
            showed.SetActive(false);
            actionElement.SetActive(true);
        }


    }
}