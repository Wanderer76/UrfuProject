using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UrfuProject
{
    public class Scroll : MonoBehaviour
    {

        public Image image;
        public Text TitleText;
        public Text DescriptionText;


        private Quest quest = Quest.EmptyQuest();
        private bool isNewQuest = false;

        public void SetQuest(Quest quest)
        {

            this.quest = quest;
        }
        public bool NeedNewQuest() => isNewQuest;

        private void FixedUpdate()
        {
            if(quest.Title !=null)
            {
                TitleText.text = quest.Title;
                DescriptionText.text = quest.MainText;
            }
        }

    }
}