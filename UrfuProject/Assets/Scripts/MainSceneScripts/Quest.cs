using System;
using System.Collections.Generic;

namespace UrfuProject
{
    public enum QuestType 
    {
        Unique,
        Regular
    }
    public enum QuestLevel 
    {
        First,
        Second,
        Third,
        Fourth
    }

    public enum ScienceType
    {
        Math,
        Physics,
        Chemestry,
        Biology
    }

    public struct Quest
    {

        public Quest(string title, string mainText, int reward, QuestType type, QuestLevel level, ScienceType science)
        {
            Title = title;
            MainText = mainText;
            Level = level;
            Reward = reward;
            Type = type;
            SceneIndex = 0;
            if (type == QuestType.Unique)
            {
                switch (science)
                {
                    case ScienceType.Math:
                        if (level == QuestLevel.First)
                            SceneIndex =  2;
                        if (level == QuestLevel.Second)
                            SceneIndex = 3;
                        break;
                    case ScienceType.Physics:
                        SceneIndex = 2;
                        break;
                    case ScienceType.Chemestry:
                        SceneIndex = 2;
                        break;
                    case ScienceType.Biology:
                        SceneIndex = 2;
                        break;
                }
            }
            else
            {
                SceneIndex = 0;
            }
        }

       

        public string Title { get; private set; }
        public string MainText { get; private set; }
        public int SceneIndex { get;  private set; }
        public QuestLevel Level { get;  private set; }
        public int Reward { get;  private set; }
        public QuestType Type { get; private set; }

    }
}