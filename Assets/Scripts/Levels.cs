using UnityEngine;
using System.Collections;

public static class Levels {

    //Loader - scene 0
    //Menu - scene 1
    //Level1 - scene ...
    //Last scene - Epilogue

    public static int TOTAL_LEVELS = 12;

    public static void LoadMenu()
    {
        Application.LoadLevel("Menu");
    }

    public static void LoadLoader()
    {
        Application.LoadLevel("Loader");
    }

    public static void LoadEpilogue()
    {
        Application.LoadLevel("Epilogue");
    }

    public static void LoadLevel(int index)
    {
        Application.LoadLevel(1 + index);
    }

    public static void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);        
    }

    public static void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public static void ResetProgress()
    {
        PlayerPrefs.DeleteKey("laserino_progress");
    }

    public static string LevelName()
    {
        return Application.loadedLevelName;
    }

    public static int LevelIndex()
    {
        return Application.loadedLevel - 1;
    }

    public static void UnlockNextLevel()
    {
        int index = Application.loadedLevel;
        if (index > LastLevelUnlocked())
        {
            PlayerPrefs.SetInt("laserino_progress", index);
        }
    }

    public static int LastLevelUnlocked()
    {
        return PlayerPrefs.GetInt("laserino_progress", 1);
    }

    public static bool IsLevelUnlocked(int index)
    {
        if (index > TOTAL_LEVELS) return false;

        return LastLevelUnlocked() >= index;
    }

    public static string LevelDescription()
    {
        switch (LevelName())
        {
            case "Intro": return "Shoot the bomb!";
            case "Reflection": return "Some walls are reflectable..";
            case "Destructable": return "And some walls are destructable";
            case "Arc": return ":-)";
            case "Maze": return "Don't burn yourself";
            case "Boxes": return "Find the right angle";
            case "Alien": return "You are not alone";
            case "Sharpshooter": return "Take your time";
            case "Assault": return "En garde!";
            case "Crossfire": return "Are they trying to kill you?";
            case "Wrong": return "Something is wrong...";
            case "Madness": return "Is this Sparta?";
            default: return "Default description";
        }
    }
}
