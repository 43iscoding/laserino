﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public static GameUI instance;
    public GameObject winScreen;
    public GameObject loseScreen;
    public AchievementPopup achievementPopup;
    public BlurOptimized blur;

    public Image levelIndex;
    public Text levelDescription;

    float blurSpeed = 0.1f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (levelDescription != null)
        {
            levelDescription.text = Levels.LevelDescription();
        }

        if (levelIndex != null)
        {
            levelIndex.sprite = GamePrefabs.instance.numbers[Levels.LevelIndex() - 1];
        }
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void HideWinScreen()
    {
        winScreen.SetActive(false);
    }

    public void BlurIn()
    {
        blur.enabled = true;
        StartCoroutine(BlurCoroutine());
    }

    IEnumerator BlurCoroutine()
    {
        while (blur.blurSize < 10)
        {
            blur.blurSize += blurSpeed;
            yield return null;
        }
    }

    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }

    public void HideLoseScreen()
    {
        loseScreen.SetActive(false);
    }

    public static void AchievementPopup(int achievement)
    {
        if (instance == null) return;

        instance.achievementPopup.Process(achievement);
    }
}
