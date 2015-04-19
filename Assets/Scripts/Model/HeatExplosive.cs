using UnityEngine;
using System.Collections;

[RequireComponent(typeof(VisibleHeating))]
public class HeatExplosive : MonoBehaviour
{

    public virtual void OnHeated()
    {
        GameObject explosion = Instantiate(GamePrefabs.instance.explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        Destroy(explosion, 5);        
    }
}
