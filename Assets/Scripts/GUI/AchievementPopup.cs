using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementPopup : MonoBehaviour {

    public Image[] images;

    Vector3 from;
    Vector2 to;

    public void Process(int achievement)
    {
        foreach (Image image in images)
        {
            image.enabled = false;
        }

        images[achievement].enabled = true;
        StartCoroutine(ProcessCoroutine());
    }
    
    IEnumerator ProcessCoroutine()
    {
        from = transform.position;
        to = transform.position;
        to.y = -to.y;
        float time = 1.337f;
        float timeLeft = time;
        while (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            transform.position = Vector3.Lerp(to, from, timeLeft / time);
            yield return null;
        }
        yield return new WaitForSeconds(1.337f);
        timeLeft = time;
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            transform.position = Vector3.Lerp(from, to, timeLeft / time);
            yield return null;
        }
    }
}
