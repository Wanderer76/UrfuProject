using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    private const string ScienceText = "Научные очки:";
    private const string MoneyText = "Деньги:";

    public GameObject panel;
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
        GameStats.OnStatsChanged.AddListener(UpdateStatisticUI);
    }
    private void UpdateStatisticUI()
    {
        sciencePointsText.text = $"{ScienceText}{GameStats.SciencePoints}";
        moneyText.text = $"{MoneyText}{GameStats.Money}";
    }

    public void OnMathBought(int count)
    {
        GameStats.Upgrade(count, GameStats.ScienceKoef.Math);
    }
    public void OnPhysicsBought(int count)
    {
        GameStats.Upgrade(count, GameStats.ScienceKoef.Physics);
    }
    public void OnBiologyBought(int count)
    {
        GameStats.Upgrade(count, GameStats.ScienceKoef.Biology);
    }
    public void OnChemestryBought(int count)
    {
        GameStats.Upgrade(count, GameStats.ScienceKoef.Chemestry);
    }

    public void OnQuitClicked()
    {
        panel.SetActive(true);
        actionElement.SetActive(false);
    }

    public void Continue()
    {
        panel.SetActive(false);
        actionElement.SetActive(true);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene((int)GameStats.Scenes.Menu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
