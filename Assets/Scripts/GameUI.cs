using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour {

    public static GameUI instance;
    public GameObject winScreen;

    void Awake()
    {
        instance = this;
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void HideWinScreen()
    {
        winScreen.SetActive(false);
    }
}
