using System.Collections.Generic;


namespace UrfuProject
{
    public interface IScienceTable
    {
        void HideQuestScroll();
        void AddQuest(Quest newQuest);
        int QuestCount();
    }
}