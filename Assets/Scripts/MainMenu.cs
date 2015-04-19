using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Fade fade;
    public GameObject mainMenu;
    public GameObject achievementsMenu;

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

    public void Achievements()
    {
        fade.FadeOut(AchievementsCallback);
    }

    void AchievementsCallback()
    {
        mainMenu.SetActive(false);
        achievementsMenu.SetActive(true);
        fade.FadeIn();
    }

    public void Menu()
    {
        fade.FadeOut(MenuCallback);
    }

    void MenuCallback()
    {
        mainMenu.SetActive(true);
        achievementsMenu.SetActive(false);
        fade.FadeIn();
    }
}
