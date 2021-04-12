using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace UrfuProject
{
    public class QuestManager : MonoBehaviour
    {
        public List<Quest> Quests { get; private set; }

        public UnityEvent<Quest> OnQuestStart;
        public static Action<int> OnQuestCompleted;
        public static UnityEvent OnQuestCountChanged = new UnityEvent();
        private readonly Database database = Database.Instance();

        public int CurrentQuestIndex { get; protected set; }

        private static QuestManager instance = null;


        private void Start()
        {
            if (instance == null)
                instance = this;
          //  DontDestroyOnLoad(gameObject);
            Quests = new List<Quest>();
            GetNewQuest();

            OnQuestCompleted = (index) =>
            {
//                Quests[index].IsCompleted = true;
                RemoveQuest(index);
            };

        }

        private void Awake()
        {
            //Quests = new List<Quest>();
           // GetNewQuest();
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

       /* public void StartQuest(int index)
        {
            //Debug.Log($"Scene index { Quests[index].SceneIndex}");
            if (Quests.Count > index)
                throw new IndexOutOfRangeException();
            CurrentQuestIndex = index;
            SceneManager.LoadScene(index);
            //OnQuestStart?.Invoke(Quests[index]);
        }*/

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