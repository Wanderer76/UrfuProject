using System.Collections.Generic;
using UnityEngine;

namespace UrfuProject
{
    public class QuestButtonDrawer : MonoBehaviour
    {
        private readonly List<QuestButton> buttons = new List<QuestButton>(6);

        public GameObject buttonPrefab;
        public QuestManager questManager;

        public void CreateButtons()
        {

            var quests = questManager.Quests;

            for (var i = 0; i < quests.Count; i++)
            {
                if (buttons.Capacity > i)
                    buttons.Add(Instantiate(buttonPrefab, transform).GetComponent<QuestButton>());
            }

            for (var i = 0; i < buttons.Count; i++)
            {
                buttons[i].SetText($"{quests[i].Title}\n{quests[i].MainText}");
                buttons[i].SceneIndex = quests[i].SceneIndex;
                buttons[i].Index = i;
            }
        }

        private void OnEnable()
        {
            CreateButtons();
        }


        private void OnDisable()
        {
            DeleteAll();
        }

        private void DeleteAll()
        {
            foreach (var v in buttons)
            {
                if (v != null)
                    v.Destroy();
            }
            buttons.Clear();
        }
    }
}