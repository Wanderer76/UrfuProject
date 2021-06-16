using System;
using System.Collections.Generic;
using System.Linq;
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


        public static void GetNewQuests()
        {
            foreach (var quest in database.GetAllQuest())
            {
                Quests.Add(quest);
            }
        }

        public static void QuestCompleted(Quest quest)
        {
            var foundQuest = Quests.Where(q => q.MainText == quest.MainText && q.Title == quest.Title && q.ScienceType == quest.ScienceType).First();
            foundQuest.Status = QuestStatus.Completed;
            database.SetStatus(quest, QuestStatus.Completed);
        }

        public static void QuestInProgress(Quest quest)
        {
            Quests.Where(q => q.MainText == quest.MainText && q.Title == quest.Title && q.ScienceType == quest.ScienceType).First().Status = QuestStatus.InPregress;
        }

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