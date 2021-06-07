using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UrfuProject
{
    public static class QuestManager
    {
        public static List<Quest> Quests { get; private set; } = new List<Quest>();
        public static UnityEvent<Quest> OnQuestStart;
        public static Action<int> OnQuestCompleted;
        public static UnityEvent OnQuestCountChanged = new UnityEvent();
        private static readonly QuestStore database = QuestStore.Instance();

        public static int CurrentQuestIndex { get; private set; }

        //private static QuestManager instance = null;
        //
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


        //private void Start()
        //{
        //    if (instance == null)
        //        instance = this;
        //
        //    Quests = new List<Quest>();
        //    GetNewQuests();
        //
        //    OnQuestCompleted = (index) =>
        //    {
        //       //Quests[index].IsCompleted = true;
        //       RemoveQuest(index);
        //    };
        //}

        public static void GetNewQuests()
        {
            foreach (var quest in database.GetAllQuest())
            {
                Quests.Add(quest);
            }
        }

       // public static void AddQuest(string title, string description, int reward, QuestLevel level, ScienceType science)
       // {
       //     if (title == string.Empty || description == string.Empty)
       //         throw new ArgumentException();
       //
       //     var quest = new Quest(title, description, reward, level, science);
       //
       //     Quests.Add(quest);
       //     OnQuestCountChanged?.Invoke();
       // }
       //
       // public static void AddQuest(Quest quest)
       // {
       //     AddQuest(quest.Title, quest.MainText, quest.Reward, quest.Level, quest.ScienceType);
       // }

        public static void RemoveQuest(int index)
        {
            if (index >= Quests.Count)
                throw new IndexOutOfRangeException($"index - {index}");
            Quests.RemoveAt(index);
            OnQuestCountChanged?.Invoke();
        }

        public static void QuestCompleted(int index)
        {
            if (Quests.Count >= index)
                throw new IndexOutOfRangeException();

            GameStatistic.Money += Quests[index].Reward;
            GameStatistic.OnStatsChanged?.Invoke();
            RemoveQuest(index);
            OnQuestCompleted?.Invoke(index);
        }

        public static void QuestCompleted()
        {

            Debug.Log($"Current index - {CurrentQuestIndex}");
            var index = CurrentQuestIndex;

            GameStatistic.Money += Quests[index].Reward;
            GameStatistic.OnStatsChanged?.Invoke();
            RemoveQuest(index);
            OnQuestCompleted?.Invoke(index);
        }

    }
}