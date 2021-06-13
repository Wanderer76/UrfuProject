using System.Collections.Generic;
using UnityEngine.Events;

namespace UrfuProject
{
    public class GameStatistic
    {

        public enum Scenes
        {
            Menu = 0,
            MainScene,
            Dock
        }

        public enum Sciences
        {
            Math = 0,
            Physics,
            Biology,
            Chemestry
        }

        public static UnityEvent OnStatsChanged = new UnityEvent();

        public static int Money { get; set; } = 1024;

        public static int SciencePoints { get; set; } = 0;

        public static int LaboratoryLevel { get; set; } = 2;

        public static int QuestCompleted { get; }


        public static Dictionary<Sciences, bool> LaboratoryBoughts = new Dictionary<Sciences, bool>
        {
            {Sciences.Math,true },
            {Sciences.Physics,false },
            {Sciences.Chemestry,false },
            {Sciences.Biology,false }
        };


        public static void AddLaboratoryPoints(Sciences koef)
        {
            switch (koef)
            {
                case Sciences.Math:
                    SciencePoints += 250;
                    break;
                case Sciences.Physics:
                    SciencePoints += 600;
                    break;
                case Sciences.Biology:
                    SciencePoints += 840;
                    break;
                case Sciences.Chemestry:
                    SciencePoints += 1024;
                    break;
            }
        }
        public static void AddQuestPoint(QuestLevel type)
        {
            switch (type)
            {
                case QuestLevel.First:
                    SciencePoints += 129;
                    break;
                case QuestLevel.Second:
                    SciencePoints += 50;
                    break;
            }
        }

        public static void Upgrade(int count, Sciences koef)
        {
            if (Money >= count)
            {
                Money -= count;
                AddLaboratoryPoints(koef);
                OnStatsChanged?.Invoke();
            }
        }
    }
}