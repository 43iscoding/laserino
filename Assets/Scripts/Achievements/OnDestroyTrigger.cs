using UnityEngine;
using System.Collections;

public class OnDestroyTrigger : MonoBehaviour {

    public string eventName;

    void OnDestroy()
    {
        Achievements.Report(eventName);
    }
}
