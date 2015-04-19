using UnityEngine;
using System.Collections;

public class Player : Cannon {    

    void Update()
    {
        if (GameLogic.instance.InputLocked())
        {
            StopShooting();
            return;
        }

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

    //Process SOS signal
}
