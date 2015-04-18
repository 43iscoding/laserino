using UnityEngine;
using System.Collections;

public class Rotating : MonoBehaviour {

    public bool clockwise = true;
    public float speed = 0.5f;
	
	void Update () {
        transform.Rotate(Vector3.up, speed);
	}
}
