using UnityEngine;
using UnityEngine.UI;

namespace UrfuProject
{
    public class BoughtScroll : MonoBehaviour
    {
        public Text MoneyText;
        public Text ScienceText;
        public void Activate(string price, string sciencePoints)
        {
            MoneyText.text = $"Необходимо денег: {price}";
            ScienceText.text = $"Необходимо научных очков: {sciencePoints}";
        }
    }
}