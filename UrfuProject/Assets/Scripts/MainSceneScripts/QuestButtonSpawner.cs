using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

namespace UrfuProject
{
    public class QuestButtonSpawner : MonoBehaviour
    {
        private readonly List<QuestButton> quests = new List<QuestButton>(6);

        public GameObject questButtonPrefab;
        public GameObject notyficationImage;

        public QuestManager questManager;

        private void Awake()
        {
            CreateButtons();
        }

        private void CreateButtons()
        {
            for (var i = 0; i < questManager.Quests.Count; i++)
            {
                if (quests.Capacity > i)
                    quests.Add(Instantiate(questButtonPrefab, transform).GetComponent<QuestButton>());
            }

            for (var i = 0; i < quests.Count; i++)
            {
                quests[i].SetText($"{questManager.Quests[i].Title}\n{questManager.Quests[i].MainText}");
                quests[i].SceneIndex = 2;
            }
        }


        private void UpdateButtons()
        {
            quests.Clear();
            foreach (var i in quests)
            {
                Destroy(i);
            }
            CreateButtons();
        }

        private void Start()
        {
            questManager.OnQuestCountChanged.AddListener(() =>
            {
                if (quests.Capacity < questManager.Quests.Count)
                    return;
                var lastQuestIndex = questManager.Quests.Count - 1;
                var button = questManager.Quests[lastQuestIndex];
                quests.Add(Instantiate(questButtonPrefab, transform).GetComponent<QuestButton>());
                quests[quests.Count - 1].SetText($"{questManager.Quests[lastQuestIndex].Title}\n{questManager.Quests[lastQuestIndex].MainText}");
            });

            questManager.OnQuestCompleted.AddListener(UpdateButtons);
        }
    }
}