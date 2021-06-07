using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UrfuProject
{
    public class UpgradeSystem : MonoBehaviour
    {

        private readonly Dictionary<string, int> upgradeText = new Dictionary<string, int>
        {
                {"Математика", 100},
                {"Физика", 120},
                { "Биология", 200},
                { "Химмия" , 220},
        };


        [SerializeField]
        private Button[] upgradeButtons;

        public void OnMathBought(int count)
        {
            GameStatistic.Upgrade(count, GameStatistic.Sciences.Math);
        }
        public void OnPhysicsBought(int count)
        {
            GameStatistic.Upgrade(count, GameStatistic.Sciences.Physics);
        }
        public void OnBiologyBought(int count)
        {
            GameStatistic.Upgrade(count, GameStatistic.Sciences.Biology);
        }
        public void OnChemestryBought(int count)
        {
            GameStatistic.Upgrade(count, GameStatistic.Sciences.Chemestry);
        }

        private void setUpgradeText()
        {
            var index = 0;
            foreach (var i in upgradeText)
            {
                upgradeButtons[index].GetComponent<Text>().text = $"{i.Key} {i.Value}";
                index++;
            }
        }

    }
}
