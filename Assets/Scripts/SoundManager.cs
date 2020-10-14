using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource asteroidBreaking;
    public AudioSource laser;
    public AudioSource thruster;

    void playAsteroidBreak()
    {
        asteroidBreaking.Play();
    }
     void playLaser()
    {
        laser.Play();
    }

    void playThruster()
    {
        thruster.Play();
    }

    void stopThruster()
    {
        thruster.Stop();
    }
}
