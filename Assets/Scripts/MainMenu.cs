using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void Play()
    {
        Levels.LoadFirstLevel();
    }

    public void Continue()
    {
        Levels.LoadSavedLevel();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
