using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class Madness : MonoBehaviour {

    public Twirl twirl;
    public float speed = 0.05f;
	
	void Update () {
        twirl.angle += speed * Time.deltaTime;
	}
}
