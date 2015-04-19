using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public static GameLogic instance;
    public Fade fade;
    public bool alwaysShoot;

    int bombsLeft;
    int enemiesLeft;

    bool inputLocked;

    bool idle = true;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        idle = true;
        fade.FadeIn();
        bombsLeft = FindObjectsOfType<Bomb>().Length;
        enemiesLeft = FindObjectsOfType<Enemy>().Length;
        inputLocked = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            idle = false;
        }
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
        Achievements.ReportLevelDone(Levels.LevelName(), enemiesLeft, idle);
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

    public void ShakeScreen(float amount, float time)
    {
        StartCoroutine(ShakeCoroutine(amount, time));
    }

    IEnumerator ShakeCoroutine(float amount, float time)
    {
        float timeLeft = time;
        Vector3 pos = Camera.main.transform.position;
        while (timeLeft > 0)
        {
            float ratio = timeLeft / time;
            Camera.main.transform.position = pos + Random.insideUnitSphere * amount * ratio;
            timeLeft -= Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.position = pos;
    }
}
