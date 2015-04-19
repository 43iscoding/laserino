using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public enum Sound
    {
        Explosion,
        Laser
    }

    public AudioClip[] explosions;
    public AudioClip[] lasers;

    public AudioSource audio;

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
        audio.volume = Random.Range(0.7f, 1);
        audio.Play();
    }

    public void Laser()
    {
        return;
        if (!laserPlaying)
        {
            Loop(lasers[Random.Range(0, lasers.Length)]);
            laserPlaying = true;
        }
    }

    public void StopLaser()
    {
        return;
        laserPlaying = false;
        audio.Stop();
    }

    public void Play(AudioClip clip)
    {
        audio.clip = clip;
        audio.loop = false;
        audio.Play();
    }

    public void Loop(AudioClip clip)
    {
        audio.clip = clip;
        audio.loop = true;
        audio.Play();
    }
}
