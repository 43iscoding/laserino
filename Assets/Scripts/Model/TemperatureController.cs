using UnityEngine;
using System.Collections;

public class TemperatureController : MonoBehaviour {

    float maxTemperature = 1;
    float minTemperature = 0;

    float temperature;
    public float heatSpeed = 0.02f;
    public float coolSpeed = 0.01f;

    bool heating;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (heating)
        {
            temperature = Mathf.Min(maxTemperature, temperature + heatSpeed);
            heating = false;
        }
        else
        {
            temperature = Mathf.Max(minTemperature, temperature - coolSpeed);
        }

        if (temperature == maxTemperature)
        {
            SendMessage("OnHeated", SendMessageOptions.DontRequireReceiver);
        }

        CustomUpdate();
	}

    protected virtual void CustomUpdate() {
        //implement this in subclasses
    }

    void OnLaserHit() {
        heating = true;
    }

    public float GetTemperature()
    {
        return temperature;
    }
}
