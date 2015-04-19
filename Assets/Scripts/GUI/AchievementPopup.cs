using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementPopup : MonoBehaviour {

    public Image[] images;
    public Transform from;
    public Transform to;

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
        transform.position = from.position;
        float time = 1.337f;
        float timeLeft = time;
        while (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            transform.position = Vector3.Lerp(to.position, from.position, timeLeft / time);
            yield return null;
        }
        yield return new WaitForSeconds(1.337f);
        timeLeft = time;
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            transform.position = Vector3.Lerp(from.position, to.position, timeLeft / time);
            yield return null;
        }
    }
}
