using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicVolume : MonoBehaviour
{
    private GameObject menuMusic;
    public AudioSource music;

    private float musicLevel = 0.5f;

    //Awake is called upon object creation
    void Awake()
    {
        //Prevents music from stopping when changing scenes
        menuMusic = GameObject.FindWithTag("Music");
        //DontDestroyOnLoad(menuMusic);
        //uncomment line above to have music persist into gameplay
        //this causes multiple music tracks playing at once when reeturning to the menu
    }

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
