using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UrfuProject
{
    public class MathScienceTable : MonoBehaviour, IScienceTable
    {
        public GameObject questScroll;
        public QuestScrollController questScrollController;
        private HashSet<Quest> availableQuests;
        public QuestManager questManager;

        private void Start()
        {
            availableQuests = new HashSet<Quest>();
        }   

        private void FixedUpdate()
        {
            foreach (var quest in questManager.Quests.Where(q => q.ScienceType == ScienceType.Math))
            {
                availableQuests.Add(quest);
            }
            if(availableQuests.Count > 0)
            {
                questScroll.SetActive(true);
                questScrollController.SetQuest(availableQuests.First());
            }
        }

        public List<Quest> GetQuests() => availableQuests.ToList();

        public void HideQuestScroll()
        {
            questScroll.SetActive(false);
        }
        public void AddQuest(Quest newQuest)
        {
            availableQuests.Add(newQuest);
        }

        public int QuestCount()
        {
            return availableQuests.Count;
        }

        public void ShowQuestScroll()
        {
            throw new System.NotImplementedException();
        }
    }
}