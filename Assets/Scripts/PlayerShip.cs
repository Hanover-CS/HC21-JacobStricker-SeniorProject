using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    public Rigidbody2D rb;

    //variables used for ship movement
    public float forward;
    public float rotation;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    private float forwardInput;
    private float rotationInput;

    //variabels used for laser emmision
    public GameObject laser;
    public Transform laserEmitter;
    public float laserThrust;
    public AudioSource sound;

    //scoring UI
    private int score;
    public TextMesh scoreText;

    //handles players death
    public bool isDead = true;
    public GameObject GameOverUI;


    // Start is called before the first frame update
    void Start()
    {
        //hides mouse cursor and set appropriate game speed
        Cursor.visible = false;
        Time.timeScale = 1f;

        //Sets starting score
        score = 0;
        scoreText.text = "SCORE: " + score;

        //get GameOverUI
        GameOverUI = GameObject.FindWithTag("GameOverUI");
    }

    // Update is called once per frame
    void Update()
    {
        //forward and rotational movement
       forwardInput = 0;
       if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetButton("joy1"))
       {
           forwardInput = 1;
       }
       rotationInput = Input.GetAxis("Horizontal");

       //Rotate ship
       transform.Rotate(Vector3.forward * rotationInput * Time.deltaTime * -rotation);

       //screen wrapping
        Vector2 newPos = transform.position;
        if (transform.position.y > screenTop)
        {
            newPos.y = screenBottom;
        }

        if (transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }

        if (transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }

        if (transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }

        transform.position = newPos;

        //Fire laser
        if (Input.GetButtonDown("fireLaser"))
        {
            GameObject newLaser = Instantiate(laser, laserEmitter.position, laserEmitter.rotation);
            newLaser.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * laserThrust);
            sound.Play();
            Destroy (newLaser, 4.0f);
        }
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce (Vector2.up * forwardInput * forward);
    }

    //Handles players death
    void OnCollisionEnter2D()
    {
        GameOverUI.SendMessage("setFinalScore", score);
        GameOverUI.SendMessage( "playerDeathWatch", isDead);
        Destroy(gameObject);
    }

    void ScorePoints(int addScore)
    {
        score += addScore;
        scoreText.text = "SCORE: " + score;
    }
}