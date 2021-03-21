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

    public Text sciencePointsText;
    public Text moneyText;

    private void Awake()
    {
        UpdateStatisticUI();
    }

    private void UpdateStatisticUI()
    {
        sciencePointsText.text = $"{ScienceText}{GameStats.SciencePoints}";
        moneyText.text = $"{MoneyText}{GameStats.Money}";
    }
    
    public void OnMathBought(int count)
    {
        if (GameStats.Money >= count)
            Upgrade(count, GameStats.ScienceKoef.Math);
    }
    public void OnPhysicsBought(int count)
    {
        if (GameStats.Money >= count)
            Upgrade(count, GameStats.ScienceKoef.Physics);
    }
    public void OnBiologyBought(int count)
    {
        if (GameStats.Money >= count)
            Upgrade(count, GameStats.ScienceKoef.Biology);
    }
    public void OnChemestryBought(int count)
    {
        if (GameStats.Money >= count)
            Upgrade(count, GameStats.ScienceKoef.Chemestry);
    }

    private void Upgrade(int count, GameStats.ScienceKoef koef)
    {
        GameStats.Money -= count;
        GameStats.AddSciencePoints(koef);
        UpdateStatisticUI();
    }

    public void OnQuitClicked()
    {
        panel.SetActive(true);
    }

    public void Continue()
    {
        panel.SetActive(false);
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
