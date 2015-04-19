using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Achievements : MonoBehaviour {

    public static int L = 0;
    public static int A = 1;
    public static int S = 2;
    public static int SHORTCUT = 3;
    public static int PACIFIST = 4;
    public static int MILITARIST = 5;
    public static int N = 6;
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
            case "L": return L;
            case "A": return A;
            case "S": return S;
            case "E": return SHORTCUT;
            case "R": return PACIFIST;
            case "I": return MILITARIST;
            case "N": return N;
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

    public static string Description(string key)
    {
        switch (key)
        {
            case "L": return "testL";
            case "A": return "testA";
            case "S": return "testS";
            case "E": return "testE";
            case "R": return "testR";
            case "I": return "testI";
            case "N": return "testN";
            case "O": return "testO";
            default: return "error";
        }
    }

    public static void ReportLevelDone(string level, int enemiesLeft)
    {
        if (level == "Assault")
        {
            if (enemiesLeft == 0)
            {
                UnlockAchievement(MILITARIST);
            }
            else
            {
                UnlockAchievement(PACIFIST);
            }
        }
    }

    public static void Report(string name)
    {
        switch (name)
        {
            case "shortcut": UnlockAchievement(SHORTCUT); break;
            default: Debug.Log("Unknown achievement event: " + name); break;
        }
    }
}
