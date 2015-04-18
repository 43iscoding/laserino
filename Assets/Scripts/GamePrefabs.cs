using UnityEngine;
using System.Collections;

public class GamePrefabs : MonoBehaviour {

    public GameObject explosion;
    public GameObject spark;

    public static GamePrefabs instance;

    void Awake()
    {
        instance = this;
    }
}
