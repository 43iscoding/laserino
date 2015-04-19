using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Achievements : MonoBehaviour {

    public static int TAOIST = 0;
    public static int RETURN = 1;
    public static int MULISH = 2;
    public static int SHORTCUT = 3;
    public static int PACIFIST = 4;
    public static int WARMONGER = 5;
    public static int FINALE = 6;
    public static int DISTRESS = 7;

    public static bool HasAchievement(string achievement)
    {
        return HasAchievement(KeyToIndex(achievement));
    }

    public static bool HasAchievement(int achievement)
    {
        return PlayerPrefs.HasKey("laserino_ach_" + achievement);
    }

    public static void UnlockAchievement(int achievement)
    {
        Debug.Log("Unlock achievement:" + achievement);
        if (HasAchievement(achievement)) return;
        PlayerPrefs.SetInt("laserino_ach_" + achievement, 1);
        GameUI.AchievementPopup(achievement);
    }

    public static int KeyToIndex(string key)
    {
        switch (key)
        {
            case "L": return TAOIST;
            case "A": return RETURN;
            case "S": return MULISH;
            case "E": return SHORTCUT;
            case "R": return PACIFIST;
            case "I": return WARMONGER;
            case "N": return FINALE;
            case "O": return DISTRESS;
            default: return -1;
        }
    }

    public static void Clear()
    {
        PlayerPrefs.DeleteKey("laserino_ach_0");
        PlayerPrefs.DeleteKey("laserino_ach_1");
        PlayerPrefs.DeleteKey("laserino_ach_2");
        PlayerPrefs.DeleteKey("laserino_ach_3");
        PlayerPrefs.DeleteKey("laserino_ach_4");
        PlayerPrefs.DeleteKey("laserino_ach_5");
        PlayerPrefs.DeleteKey("laserino_ach_6");
        PlayerPrefs.DeleteKey("laserino_ach_7");
    }

    public static string Name(string key)
    {
        switch (key)
        {
            case "L": return "Taoist";
            case "A": return "Return";
            case "S": return "Mulish";
            case "E": return "Shortcut";
            case "R": return "Pacifist";
            case "I": return "Warmonger";
            case "N": return "Finale";
            case "O": return "Distress";
            default: return "error";
        }  
    }

    public static string Description(string key)
    {
        switch (key)
        {
            case "L": return "Wait by the river...";
            case "A": return "Go have some sleep";
            case "S": return "That thing IS destructible";
            case "E": return "Who likes arcs anyway?";
            case "R": return "Ignore him!";
            case "I": return "Punish him!";
            case "N": return "Make it to the end";
            case "O": return "Call for help!";
            default: return "error";
        }
    }

    public static void ReportLevelDone(string level, int enemiesLeft, bool idle)
    {
        if (level == "Assault" && enemiesLeft != 0)
        {
            UnlockAchievement(PACIFIST);
        }

        if (level == "Crossfire" && idle)
        {
            UnlockAchievement(TAOIST);
        }
    }

    public static void Report(string name)
    {
        switch (name)
        {
            case "shortcut": UnlockAchievement(SHORTCUT); break;
            case "militarist": UnlockAchievement(WARMONGER); break;
            case "stubborn": UnlockAchievement(MULISH); break;
            default: Debug.Log("Unknown achievement event: " + name); break;
        }
    }

    public static string Progress()
    {
        int completed = 0;
        for (int i = 0; i < 8; i++)
        {
            if (PlayerPrefs.HasKey("laserino_ach_" + i)) completed++;
        }
        return "You have completed " + completed + "/8 achievements";
    }
}
