using UnityEngine;
using System.Collections;

[RequireComponent(typeof(VisibleHeating))]
public class HeatExplosive : MonoBehaviour
{
    public bool big = false;

    public virtual void OnHeated()
    {
        GameObject prefab = big ? GamePrefabs.instance.explosionBig : GamePrefabs.instance.explosion;
        GameObject explosion = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        SoundManager.instance.Explosion(explosion);
        Destroy(gameObject);
        Destroy(explosion, 5);        
    }
}
