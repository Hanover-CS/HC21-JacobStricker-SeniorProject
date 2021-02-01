using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustFlame : MonoBehaviour
{
    public ParticleSystem ps;
    public GameObject soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindWithTag("soundManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("xBoxButtonA"))
            {
                ps.Play();
                soundManager.SendMessage("playThruster");
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetButtonUp("xBoxButtonA"))
            {
                ps.Stop();
                soundManager.SendMessage("stopThruster");
            }
        }
    }
}
