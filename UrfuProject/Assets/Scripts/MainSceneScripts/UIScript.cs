using UnityEngine;
using UnityEngine.UI;

namespace UrfuProject
{
    public class UIScript : MonoBehaviour
    {

        private const string ScienceText = "Научные очки";
        private const string MoneyText = "Деньги";

        public GameObject exitPanel;
        public Text sciencePointsText;
        public Text moneyText;

        private void Awake()
        {
            UpdateStatisticUI();
        }
        private void Start()
        {
            GameStatistic.OnStatsChanged.AddListener(UpdateStatisticUI);
            QuestManager.OnQuestCountChanged.AddListener(() =>
            {
            });
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ShowExitPanel();
            }
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
            Time.timeScale = 1;
            LevelManager.LoadLevel(Scenes.MenuScene);
        }

        public void Quit()
        {
            Application.Quit();
        }

        private void ActivatePanel(GameObject showed)
        {
            showed.SetActive(true);
        }
        private void DeactivatePanel(GameObject showed)
        {
            Time.timeScale = 1;
            showed.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void ShowExitPanel()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            exitPanel.SetActive(true);
        }
    }
}