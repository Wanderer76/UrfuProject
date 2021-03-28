using System.Collections.Generic;
using UnityEngine;

namespace UrfuProject
{
    public class QuestButtonDrawer : MonoBehaviour
    {
        private readonly List<QuestButton> buttons = new List<QuestButton>(6);

        public GameObject buttonPrefab;
        public GameObject parents;
        public QuestManager questManager;


        private void Start()
        {
            /* QuestManager.OnQuestCountChanged.AddListener(() =>
             {
                 if (buttons.Capacity < questManager.Quests.Count)
                     return;
                 var lastQuestIndex = questManager.Quests.Count - 1;
                 var button = questManager.Quests[lastQuestIndex];
                 buttons.Add(Instantiate(buttonPrefab, transform).GetComponent<QuestButton>());
                 buttons[buttons.Count - 1].SetText($"{questManager.Quests[lastQuestIndex].Title}\n{questManager.Quests[lastQuestIndex].MainText}");
             });*/

            QuestButton.OnDelete.AddListener(() =>
            {
                questManager.RemoveQuest(0);
            });

        }

        public void CreateButtons()
        {
            for (var i = 0; i < questManager.Quests.Count; i++)
            {
                if (buttons.Capacity > i)
                    buttons.Add(Instantiate(buttonPrefab, parents.transform).GetComponent<QuestButton>());
            }

            for (var i = 0; i < buttons.Count; i++)
            {
                buttons[i].SetText($"{questManager.Quests[i].Title}\n{questManager.Quests[i].MainText}");
                buttons[i].SceneIndex = 2;
                buttons[i].Index = i;
                Debug.Log($"{buttons[i]}");
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