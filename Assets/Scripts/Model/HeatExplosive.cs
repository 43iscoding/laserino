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
        if (big) {
            GameLogic.instance.ShakeScreen(1f, 0.8f);
        }
        else
        {
            GameLogic.instance.ShakeScreen(0.5f, 0.5f);
        }
        Destroy(gameObject);
        Destroy(explosion, 1);        
    }

    
}
