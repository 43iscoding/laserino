using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {

    public Transform from;
    public Transform to;

    public float time;

    float timeLeft;
    bool movingTo;

	void Update () {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (movingTo)
            {
                transform.position = Vector3.Lerp(to.position, from.position, timeLeft / time);
            }
            else
            {
                transform.position = Vector3.Lerp(from.position, to.position, timeLeft / time);
            }

        }
        else
        {
            timeLeft = time;
            movingTo = !movingTo;
        }
	}
}
