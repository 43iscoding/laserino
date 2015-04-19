using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public static GameLogic instance;
    public Fade fade;
    public bool alwaysShoot;

    int bombsLeft;
    int enemiesLeft;

    bool inputLocked;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        fade.FadeIn();
        bombsLeft = FindObjectsOfType<Bomb>().Length;
        enemiesLeft = FindObjectsOfType<Enemy>().Length;
        inputLocked = false;
    }

    public void OnPlayerDied()
    {
        StartCoroutine(Lose());
    }

    public void OnEnemyDied()
    {
        enemiesLeft--;
        Debug.Log("Enemy died");
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
        GameUI.instance.BlurIn();
        yield return new WaitForSeconds(1.337f);
        GameUI.instance.ShowLoseScreen();
    }

    IEnumerator Win()
    {
        inputLocked = true;
        Achievements.ReportLevelDone(Levels.LevelName(), enemiesLeft);
        Levels.UnlockNextLevel();
        GameUI.instance.BlurIn();
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
