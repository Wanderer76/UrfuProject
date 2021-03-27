namespace UrfuProject
{
    public enum QuestType 
    {
        Unique,
        Regular
    }

    public struct Quest
    {
        public Quest(string title, string mainText, int sceneIndex, int reward, QuestType type)
        {
            Title = title;
            MainText = mainText;
            SceneIndex = sceneIndex;
            Reward = reward;
            Type = type;
        }

        public string Title { get; private set; }
        public string MainText { get; private set; }
        public int SceneIndex { get;  private set; }
        public int Reward { get;  private set; }
        public QuestType Type { get; private set; }

    }
}