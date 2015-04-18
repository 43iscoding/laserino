using UnityEngine;
using System.Collections;

public class Bomb : HeatExplosive {

    public override void OnHeated()
    {
        base.OnHeated();
        GameLogic.instance.OnBombExploded();
    }
}
