using System.Collections.Generic;


namespace UrfuProject
{
    public interface IScienceTable
    {
        void ShowAvailableIndicator();
        void HideScroll();
        void ShowScroll();
        void HideQuestScroll();
        void AddQuest(Quest newQuest);
        int QuestCount();
        void AcceptQuest();
    }
}