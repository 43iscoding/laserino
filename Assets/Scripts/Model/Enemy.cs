using UnityEngine;
using System.Collections;

public class Enemy : Cannon {
	
	void Update () {
        if (GameLogic.instance.InputLocked())
        {
            StopShooting();
        }
        else
        {
            Shoot();
        }
	}
}
