using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UrfuProject
{
    public class QuestManager : MonoBehaviour
    {
        public List<Quest> Quests { get; private set; }

        public UnityEvent<Quest> OnQuestStart;
        public UnityEvent OnQuestCompleted;
        public UnityEvent OnQuestCountChanged;

        private void Start()
        {
            Quests = new List<Quest>();
            AddQuest("Матан", "Взвесить", QuestLevel.First, 230, QuestType.Unique);
            AddQuest("Матан", "Взвесить", QuestLevel.First, 230, QuestType.Unique);
        }

        public void AddQuest(string title,string description, QuestLevel level,int reward, QuestType type)
        {
            if(title == string.Empty || description == string.Empty)
                throw new ArgumentException();

            var quest = new Quest(title, description, reward, type, level);
            Quests.Add(quest);
            OnQuestCountChanged?.Invoke();
        }

        public void StartQuest(int index)
        {
            if (Quests.Count >= index)
                throw new IndexOutOfRangeException();
            OnQuestStart?.Invoke(Quests[index]);
        }

        public void RemoveQuest(int index)
        {
            if (index >= Quests.Count)
                throw new IndexOutOfRangeException($"index - {index}");
            Quests.RemoveAt(index);
        }

        public void QuestCompleted(int index)
        {
            if (Quests.Count > index)
                throw new IndexOutOfRangeException();

            GameStatistic.Money += Quests[index].Reward;
            GameStatistic.AddQuestPoint(Quests[index].Type);
            GameStatistic.OnStatsChanged?.Invoke();
            RemoveQuest(index);
            OnQuestCompleted?.Invoke();
        }

    }
}