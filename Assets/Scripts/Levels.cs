using UnityEngine;
using System.Collections;

public static class Levels {

    //Loader - scene 0
    //Menu - scene 1
    //Level1 - scene

    public static int totalLevels = 3;

    public static void LoadMenu()
    {
        Application.LoadLevel("Menu");
    }

    public static void LoadEpilogue()
    {
        Application.LoadLevel("Epilogue");
    }

    public static void LoadFirstLevel()
    {
        Application.LoadLevel(2);
    }

    public static void LoadSavedLevel()
    {
        Debug.LogError("Not implemented: loading first level");
        LoadFirstLevel();
    }

    public static void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);        
    }

    public static void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
