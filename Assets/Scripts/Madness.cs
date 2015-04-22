using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEditor;

public class Madness : MonoBehaviour {

    Twirl twirl;
    public float speed = 5f;
    public bool cycle = true;

    public float from;
    public float to;

    bool direction;

    void Start()
    {
        twirl = GetComponent<Twirl>();
        if (twirl == null)
        {
            Debug.LogError("No Twirl Component found for " + gameObject);
        }

        if (!cycle)
        {
            speed = Mathf.Abs(speed);
            if (from > to)
            {
                speed *= -1;
            }
        }
    }
	
	void Update () {
        if (twirl == null) return;

        if (cycle)
        {
            twirl.angle += speed * Time.deltaTime;
        }
        else
        {
            if (direction)
            {
                twirl.angle += speed * Time.deltaTime;
                if (twirl.angle >= to)
                {
                    direction = false;
                }
            }
            else
            {
                twirl.angle -= speed * Time.deltaTime;
                if (twirl.angle <= from)
                {
                    direction = true;
                }
            }
        }
	}
}

[CustomEditor(typeof(Madness))]
public class MadnessEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Madness madness = target as Madness;
        
        madness.speed = EditorGUILayout.FloatField("Speed", madness.speed);
        madness.cycle = GUILayout.Toggle(madness.cycle, "Cycle");

        if (!madness.cycle)
        {
            madness.from = EditorGUILayout.FloatField("From", madness.from);
            madness.to = EditorGUILayout.FloatField("To", madness.to);
        }

    }
} 
