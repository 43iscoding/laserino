using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Cannon {

    List<float> buffer = new List<float>(9);
    float currentSignal;

    void Update()
    {
        if (GameLogic.instance.InputLocked())
        {
            StopShooting();
            return;
        }

        ProcessSOS();

        Rotate();
        if (Input.GetMouseButton(0) || GameLogic.instance.alwaysShoot)
        {
            Shoot();
        }
        else
        {
            StopShooting();
        }
    }

    public override void OnHeated()
    {
        base.OnHeated();
        GameLogic.instance.OnPlayerDied();
    }

    void ProcessSOS()
    {
        if (Achievements.HasAchievement(Achievements.DISTRESS)) return;

        if (Input.GetMouseButton(0))
        {
            currentSignal += Time.deltaTime;
        }
        else
        {
            if (currentSignal != 0)
            {
                if (buffer.Count == 9) {
                    buffer.RemoveAt(0);
                }
                buffer.Add(currentSignal);
                currentSignal = 0;
                CheckSOS();
            }
        }
    }

    void CheckSOS()
    {
        if (buffer.Count != 9) return;

        for (int i = 0; i < 9; i++)
        {
            if (i < 3 || i > 5)
            {
                if (buffer[i] > 0.3f) return;
            }
            else
            {
                if (buffer[i] < 0.3f) return;
            }
        }
        Achievements.UnlockAchievement(Achievements.DISTRESS);
    }
}
