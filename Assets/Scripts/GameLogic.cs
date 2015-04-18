using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public static GameLogic instance;
    public Fade fade;
    public bool alwaysShoot;

    int bombsLeft;

    bool inputLocked;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        fade.FadeIn();
        bombsLeft = FindObjectsOfType<Bomb>().Length;
        inputLocked = false;
    }

    public void OnCannonExploded()
    {
        StartCoroutine(Lose());
    }

    public void OnBombExploded()
    {
        bombsLeft--;

        if (bombsLeft == 0)
        {
            StartCoroutine(Win());
        }
    }

    IEnumerator Lose()
    {
        inputLocked = true;
        yield return new WaitForSeconds(1.337f);
        GameUI.instance.ShowLoseScreen();
    }

    IEnumerator Win()
    {
        inputLocked = true;
        yield return new WaitForSeconds(1.337f);
        GameUI.instance.ShowWinScreen();
    }

    public bool InputLocked()
    {
        return inputLocked;
    }

    public void Replay()
    {
        fade.FadeOut(ReplayCallback);
    }

    void ReplayCallback()
    {
        Levels.ReloadLevel();
    }

    public void NextLevel()
    {
        fade.FadeOut(NextLevelCallback);
    }

    void NextLevelCallback()
    {
        Levels.LoadNextLevel();
    }

    public void MainMenu()
    {
        fade.FadeOut(MainMenuCallback);
    }

    void MainMenuCallback()
    {
        Levels.LoadMenu();
    }
}
