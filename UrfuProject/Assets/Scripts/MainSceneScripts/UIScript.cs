using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UrfuProject
{
    public class UIScript : MonoBehaviour
    {

        private const string ScienceText = "Научные очки:";
        private const string MoneyText = "Деньги:";

        public GameObject exitPanel;
        public GameObject questsPanel;
        private GameObject actionElement;

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
        }
        private void UpdateStatisticUI()
        {
            sciencePointsText.text = $"{ScienceText}{GameStatistic.SciencePoints}";
            moneyText.text = $"{MoneyText}{GameStatistic.Money}";
        }

        public void OnQuitClicked()
        {
            exitPanel.SetActive(true);
            actionElement.SetActive(false);
        }

        public void Continue()
        {
            exitPanel.SetActive(false);
            actionElement.SetActive(true);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene((int)GameStatistic.Scenes.Menu);
        }

        public void ShowQuestsTable()
        {
            questsPanel.SetActive(true);
            actionElement.SetActive(false);
        }
        public void HideQuestsTable()
        {
            questsPanel.SetActive(false);
            actionElement.SetActive(true);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}