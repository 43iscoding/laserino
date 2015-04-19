using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Epilogue : MonoBehaviour {
    
    public Fade fade;
    public Text progress;

	void Start () {
        StartCoroutine(EpilogueCoroutine());
	}

    IEnumerator EpilogueCoroutine()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1f);
        Achievements.UnlockAchievement(Achievements.FINALE);
        yield return new WaitForSeconds(4f);
        fade.FadeOut();
        yield return new WaitForSeconds(2f);
        Levels.LoadMenu();
    }

    void Update()
    {
        progress.text = Achievements.Progress();
    }
}
