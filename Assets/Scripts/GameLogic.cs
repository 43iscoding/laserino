using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public static GameLogic instance;
    public bool alwaysShoot;

    int bombsLeft;

    bool inputLocked;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        bombsLeft = FindObjectsOfType<Bomb>().Length;
        inputLocked = false;
    }

    public void OnBombExploded()
    {
        bombsLeft--;

        if (bombsLeft == 0)
        {
            StartCoroutine(Win());
        }
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
        Application.LoadLevel(Application.loadedLevel);
    }

    public void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
