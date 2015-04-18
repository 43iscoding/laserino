using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Fade fade;

    void Start()
    {
        fade.FadeIn();
    }

    public void Play()
    {
        fade.FadeOut(PlayCallback);
    }

    void PlayCallback()
    {
        Levels.LoadFirstLevel();
    }

    public void Continue()
    {
        Levels.LoadSavedLevel();
    }

    public void Exit()
    {
        fade.FadeOut(ExitCallback);
    }

    void ExitCallback()
    {
        Application.Quit();
    }
}
