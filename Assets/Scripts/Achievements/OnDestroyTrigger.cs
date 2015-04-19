using UnityEngine;
using System.Collections;

public class OnDestroyTrigger : MonoBehaviour {

    public string eventName;

    void OnHeated()
    {
        Achievements.Report(eventName);
    }
}
