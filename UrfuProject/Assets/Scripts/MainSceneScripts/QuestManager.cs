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
        public UnityEvent<int> OnQuestCompleted;
        public static UnityEvent OnQuestCountChanged = new UnityEvent();

        private readonly Database database = Database.Instance();


        private void Start()
        {
            Quests = new List<Quest>();
            GetNewQuest();
        }

        private void GetNewQuest()
        {
            //TODO Здесь квесты должны будут получатся из базы данных
            AddQuest("Матан", "Взвесить", QuestLevel.First, 230, QuestType.Unique, ScienceType.Math);
            AddQuest("Матан", "Что то", QuestLevel.Second, 230, QuestType.Unique, ScienceType.Math);
        }


        public void AddQuest(string title,string description, QuestLevel level,int reward, QuestType type, ScienceType science)
        {
            if(title == string.Empty || description == string.Empty)
                throw new ArgumentException();

            var quest = new Quest(title, description, reward, type, level, science);
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
            OnQuestCountChanged?.Invoke();
        }

        public void QuestCompleted(int index)
        {
            if (Quests.Count >= index)
                throw new IndexOutOfRangeException();

            GameStatistic.Money += Quests[index].Reward;
            GameStatistic.AddQuestPoint(Quests[index].Type);
            GameStatistic.OnStatsChanged?.Invoke();
            RemoveQuest(index);
            OnQuestCompleted?.Invoke(index);
        }

    }
}