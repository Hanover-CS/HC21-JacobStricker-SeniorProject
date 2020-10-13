using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBreakingSoundScript : MonoBehaviour
{
    public AudioSource asteroidBreakingSound;

    void playSound()
    {
        asteroidBreakingSound.Play();
    }
}
