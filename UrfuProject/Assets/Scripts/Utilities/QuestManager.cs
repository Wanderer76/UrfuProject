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
        public Action<int> OnQuestCompleted;
        public static UnityEvent OnQuestCountChanged = new UnityEvent();
        private readonly Database database = Database.Instance();

        public int CurrentQuestIndex { get; private set; }

        private static QuestManager instance = null;

        //public static QuestManager Instance()
        //{
        //    if (instance == null)
        //    {
        //        instance = new QuestManager();
        //
        //        Quests = new List<Quest>();
        //        GetNewQuests();
        //
        //        OnQuestCompleted = (index) =>
        //        {
        //            //Quests[index].IsCompleted = true;
        //            RemoveQuest(index);
        //        };
        //    }
        //    return instance;
        //}


        private void Start()
        {
            if (instance == null)
                instance = this;

            Quests = new List<Quest>();
            GetNewQuests();

            OnQuestCompleted = (index) =>
            {
               //Quests[index].IsCompleted = true;
               RemoveQuest(index);
            };
        }

        public void GetNewQuests()
        {
            foreach (var quest in database.GetAllQuest())
                AddQuest(quest);
        }

        public void AddQuest(string title, string description, int reward, QuestType type, QuestLevel level, ScienceType science)
        {
            if (title == string.Empty || description == string.Empty)
                throw new ArgumentException();

            var quest = new Quest(title, description, reward, type, level, science);
            Quests.Add(quest);
            OnQuestCountChanged?.Invoke();
        }

        public void AddQuest(Quest quest)
        {
            AddQuest(quest.Title, quest.MainText, quest.Reward, quest.Type, quest.Level, quest.ScienceType);
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

        public void QuestCompleted()
        {

            Debug.Log($"Current index - {CurrentQuestIndex}");
            var index = CurrentQuestIndex;

            GameStatistic.Money += Quests[index].Reward;
            GameStatistic.AddQuestPoint(Quests[index].Type);
            GameStatistic.OnStatsChanged?.Invoke();
            RemoveQuest(index);
            OnQuestCompleted?.Invoke(index);
        }

    }
}