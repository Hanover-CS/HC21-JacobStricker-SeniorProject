using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicVolume : MonoBehaviour
{
    public AudioSource music;

    private float musicLevel = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = musicLevel;
    }

    public void updateVolume(float volume)
    {
        musicLevel = volume;
    }
}
