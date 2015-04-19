using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Fade fade;
    public GameObject mainMenu;
    public GameObject achievementsMenu;
    public GameObject levelSelection;

    public static MainMenu instance;

    int selectedLevel = 1;

    void Awake()
    {
        instance = this;
    }

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
        Levels.LoadLevel(selectedLevel);
    }

    public void Exit()
    {
        fade.FadeOut(ExitCallback);
    }

    void ExitCallback()
    {
        Application.Quit();
    }

    public void OpenAchievements()
    {
        fade.FadeOut(AchievementsCallback);
    }

    void AchievementsCallback()
    {
        mainMenu.SetActive(false);
        levelSelection.SetActive(false);
        achievementsMenu.SetActive(true);
        fade.FadeIn();
    }

    public void Menu()
    {
        fade.FadeOut(MenuCallback);
    }

    void MenuCallback()
    {
        achievementsMenu.SetActive(false);
        levelSelection.SetActive(false);
        mainMenu.SetActive(true);
        fade.FadeIn();
    }

    public void LevelSelection()
    {
        fade.FadeOut(LevelSelectionCallback);
    }

    void LevelSelectionCallback()
    {
        achievementsMenu.SetActive(false);
        mainMenu.SetActive(false);
        levelSelection.SetActive(true);
        fade.FadeIn();
    }

    public void OnLevelSelect(int index)
    {
        selectedLevel = index;
        Debug.Log("Level: " + index);
    }

    public void ResetProgress()
    {
        Achievements.Clear();
        Levels.ResetProgress();
        Levels.LoadMenu();
    }
}
