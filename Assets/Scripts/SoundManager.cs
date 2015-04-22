using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public enum Sound
    {
        Explosion,
        Laser
    }

    public AudioClip[] explosions;
    public AudioClip laser;
    public AudioClip music;

    public static SoundManager instance;

    bool laserPlaying = false;

    void Awake()
    {
        instance = this;
    }

    public void Explosion(GameObject source)
    {
        AudioSource audio = source.AddComponent<AudioSource>();
        audio.clip = explosions[Random.Range(0, explosions.Length)];
        audio.volume = Random.Range(0.15f, 0.25f);
        audio.Play();
    }
}
