using System.Collections.Generic;


namespace UrfuProject
{
    public interface IScienceTable
    {
        void ShowQuestScroll();
        void HideQuestScroll();
        void AddQuest(Quest newQuest);
        int QuestCount();
        List<Quest> GetQuests();
    }
}