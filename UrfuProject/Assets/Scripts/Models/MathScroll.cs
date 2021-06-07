using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UrfuProject
{
    public class MathScroll : MonoBehaviour
    {
        public GameObject[] QuestsPrefabs;
        public Image image;
        public Text TitleText;
        public Text DescriptionText;

        private Quest Quest;

        public void SetQuest(Quest quest)
        {
            Quest = quest;
            TitleText.text = quest.Title;
            DescriptionText.text = quest.MainText;
        }
        public bool NeedNewQuest() => Quest == null;
    }
}