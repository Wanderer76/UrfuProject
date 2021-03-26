using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UrfuProject
{
    public class QuestManager : MonoBehaviour
    {
        public List<Quest> Quests { get; private set; }

        public UnityEvent<Quest> OnQuestStart;

        public QuestManager()
        {
            Quests = new List<Quest>();
        }

        public void AddQuest(string title,string description, int sceneIndex,int reward, QuestType type)
        {
            if(title == string.Empty || description == string.Empty)
                throw new ArgumentException();

            var quest = new Quest(title, description, sceneIndex, reward, type);
            Quests.Add(quest);
        }

        public void StartQuest(int index)
        {
            if (Quests.Count >= index)
                throw new IndexOutOfRangeException();
            OnQuestStart?.Invoke(Quests[index]);
        }

        public void RemoveQuest(int index)
        {
            if (Quests.Count >= index)
                throw new IndexOutOfRangeException();
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
        }

    }
}