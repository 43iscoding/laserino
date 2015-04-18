using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TemperatureController))]
public class Bomb : MonoBehaviour {

    void OnHeated()
    {
        GameObject explosion = Instantiate(GamePrefabs.instance.explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        Destroy(explosion, 5);
        GameLogic.instance.OnBombExploded();
    }
}
