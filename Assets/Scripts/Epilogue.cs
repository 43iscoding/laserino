using UnityEngine;
using System.Collections;

public class Epilogue : MonoBehaviour {
    
    public Fade fade;

	void Start () {
        StartCoroutine(EpilogueCoroutine());
	}

    IEnumerator EpilogueCoroutine()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(4f);
        fade.FadeOut();
        yield return new WaitForSeconds(2f);
        Levels.LoadMenu();
    }
}
