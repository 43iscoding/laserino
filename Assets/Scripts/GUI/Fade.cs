using UnityEngine;
using System.Collections;
using System;

public class Fade : MonoBehaviour {

    public CanvasRenderer image;
    public Canvas canvas;
    float fadeSpeed = 0.02f;

    public void FadeIn(Action callback = null)
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeCoroutine(0, callback));
    }

    public void FadeOut(Action callback = null)
    {
        StartCoroutine(FadeCoroutine(1, callback));
    }

    IEnumerator FadeCoroutine(int to, Action callback)
    {
        canvas.sortingOrder = 1;
        image.SetAlpha(1 - to);
        while (image.GetAlpha() != to)
        {
            if (to == 1)
            {
                image.SetAlpha(Mathf.Min(to, image.GetAlpha() + fadeSpeed));
            }
            else
            {
                image.SetAlpha(Mathf.Max(to, image.GetAlpha() - fadeSpeed));
            }
            
            yield return null;
        }
        canvas.sortingOrder = -1 + to;
        if (callback != null)
        {
            callback();
        }
    }
}
