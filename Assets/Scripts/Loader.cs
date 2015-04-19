using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
    public CanvasRenderer image;

    float fadeSpeed = 0.01f;

    void Start()
    {
        ReturnAchievement();
        StartCoroutine(PlayLoader());
    }

    void ReturnAchievement()
    {
        if (PlayerPrefs.HasKey("laserino_return"))
        {
            Achievements.UnlockAchievement(Achievements.RETURN);
        }
        else
        {
            PlayerPrefs.SetInt("laserino_return", 1);
        }
    }

    IEnumerator PlayLoader()
    {
        image.SetAlpha(0);
        //fade in logo
        Debug.Log("Fade in");
        while (image.GetAlpha() != 1)
        {
            image.SetAlpha(Mathf.Min(1, image.GetAlpha() + fadeSpeed));
            yield return null;
        }
        //wait
        Debug.Log("Wait");
        yield return new WaitForSeconds(1.337f);
        //fade out logo
        Debug.Log("Fade out");
        while (image.GetAlpha() != 0)
        {
            image.SetAlpha(Mathf.Max(0, image.GetAlpha() - fadeSpeed));
            yield return null;
        }
        yield return new WaitForSeconds(1.337f);
        Levels.LoadMenu();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Levels.LoadMenu();
        }
    }
}
