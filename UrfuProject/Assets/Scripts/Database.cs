using System;
using System.Collections.Generic;
using System.Linq;

namespace UrfuProject
{
    public class Database
    {
        private static Database instance;


        private readonly Dictionary<ScienceType, List<Quest>> data = new Dictionary<ScienceType, List<Quest>>
        {
            {ScienceType.Math, new List<Quest>{new Quest("Матан", "Взвесить", 230, QuestType.Unique, QuestLevel.First, ScienceType.Math)} },
            {ScienceType.Physics, new List<Quest>{ new Quest("Физика", "Найти оптимальную массу", 230, QuestType.Unique, QuestLevel.Second, ScienceType.Physics)} },
        };


        public static Database Instance()
        {
            if (instance == null)
                instance = new Database();
            return instance;
        }

        public int QuestCount()
        {
            return data
                .SelectMany(quest => quest.Value)
                .Count();
        }

        public IEnumerable<Quest> GetAllQuest()
        {
            return data
                .SelectMany(quest => quest.Value);
        }

        public Quest GetRandomQuest(ScienceType type)
        {
            var typeQuests = data[type];
            return typeQuests[new Random().Next(0, typeQuests.Count - 1)];
        }
    }
}