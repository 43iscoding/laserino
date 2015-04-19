using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Achievements : MonoBehaviour {

    public static int L = 0;
    public static int A = 1;
    public static int S = 2;
    public static int E = 3;
    public static int R = 4;
    public static int I = 5;
    public static int N = 6;
    public static int O = 7;

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
        if (HasAchievement(achievement)) return;

        Debug.Log("Unlock achievement:" + achievement);
        PlayerPrefs.SetInt("laserino_ach_" + achievement, 1);
        GameUI.AchievementPopup(achievement);
    }

    public static int KeyToIndex(string key)
    {
        switch (key)
        {
            case "L": return 0;
            case "A": return 1;
            case "S": return 2;
            case "E": return 3;
            case "R": return 4;
            case "I": return 5;
            case "N": return 6;
            case "O": return 7;
            default: return -1;
        }
    }

    public static void Clear()
    {
        PlayerPrefs.DeleteKey("laserino_ach_L");
        PlayerPrefs.DeleteKey("laserino_ach_A");
        PlayerPrefs.DeleteKey("laserino_ach_S");
        PlayerPrefs.DeleteKey("laserino_ach_E");
        PlayerPrefs.DeleteKey("laserino_ach_R");
        PlayerPrefs.DeleteKey("laserino_ach_I");
        PlayerPrefs.DeleteKey("laserino_ach_N");
        PlayerPrefs.DeleteKey("laserino_ach_O");
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
}
