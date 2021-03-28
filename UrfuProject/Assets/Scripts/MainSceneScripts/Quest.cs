using System;

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

    public class Quest
    {
        public Quest(string title, string mainText, int reward, QuestType type, QuestLevel level)
        {
            Title = title;
            MainText = mainText;
            Level = level;
            Reward = reward;
            Type = type;
            if(type == QuestType.Regular)
            {
                throw new Exception("not created");
            }
            else
            {
                switch (level)
                {
                    case QuestLevel.First:
                        SceneIndex = (int)QuestLevel.First + (int)GameStatistic.Sciences.Math;
                        break;
                    default:
                        throw new ArgumentException();
                }
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