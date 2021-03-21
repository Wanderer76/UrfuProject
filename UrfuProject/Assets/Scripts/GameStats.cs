using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStats
{

    public enum Scenes
    {
        Menu = 0,
        MainScene,
    }

    public enum ScienceKoef
    {
        Math = 0,
        Physics,
        Biology,
        Chemestry
    }

    public static int Money { get; set; } = 1024;

    public static int SciencePoints { get; private set; } = 0;

    public static int LaboratoryLevel { get; set; } = 2;

    public static int QuestCompleted { get; }

    public static List<string> CurrentQuestions { get; }

    public static void AddSciencePoints(ScienceKoef koef)
    {
        switch (koef)
        {
            case ScienceKoef.Math:
                SciencePoints += 30;
                break;
            case ScienceKoef.Physics:
                SciencePoints += 100;
                break;
            case ScienceKoef.Biology:
                SciencePoints += 130;
                break;
            case ScienceKoef.Chemestry:
                SciencePoints += 200;
                break;
        }
    }
}
