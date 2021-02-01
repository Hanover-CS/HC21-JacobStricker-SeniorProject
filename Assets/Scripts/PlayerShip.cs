using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    public Rigidbody2D rb;

    //variables used for ship movement
    private float forwardThrust = 3;
    private float rotationForce = 145;
    private float screenTop = 11;
    private float screenBottom = -11;
    private float screenLeft = (float) -18.5;
    private float screenRight = (float) 18.5;
    private float forwardInput = 0;
    private float rotationInput = 0;

    //variabels used for laser emmision
    public GameObject laser;
    public Transform laserEmitter;
    public float laserThrust = 500;
    public GameObject soundManager;

    //scoring UI
    private int score = 0;
    private GameObject scoreUI;

    //Game Over
    private GameObject GameOverUI;

    void Awake()
    {
        //get GameObjects
        GameOverUI = GameObject.FindWithTag("GameOverUI");
        soundManager = GameObject.FindWithTag("soundManager");
        scoreUI = GameObject.FindWithTag("scoreDisplay1");
        //rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    // Start is called before the first frame update
    void Start()
    {
        //hides mouse cursor and set appropriate game speed
        Cursor.visible = false;
        Time.timeScale = 1f;
        //Sets starting score
        scoreUI.SendMessage("updateScore", score);
    }

    // Update is called once per frame
    void Update()
    {
        //forward and rotational movement
       forwardInput = 0;
       if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetButton("xBoxButtonA"))
       {
           forwardInput = 1;
       }
       rotationInput = Input.GetAxis("Horizontal");

       //Rotate ship
       transform.Rotate(Vector3.forward * rotationInput * Time.deltaTime * -rotationForce);

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
        if (Input.GetButtonDown("fireLaser") && (Time.timeScale != 0))
        {
            GameObject newLaser = Instantiate(laser, laserEmitter.position, laserEmitter.rotation);
            newLaser.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * laserThrust);
            soundManager.SendMessage("playLaser");
            Destroy (newLaser, 4.0f);
        }
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce (Vector2.up * forwardInput * forwardThrust);
    }

    //Handles players death
    void OnCollisionEnter2D()
    {
        soundManager.SendMessage("stopThruster");
        GameOverUI.SendMessage("setFinalScore", score);
        GameOverUI.SendMessage( "playerDeathWatch", true);
        Destroy(gameObject);
    }

    public void ScorePoints(int addScore)
    {
        score += addScore;
        scoreUI.SendMessage("updateScore", score);
    }

    float getFowardThrust()
    {
        return forwardThrust;
    }

    //function used for testing
    public int getScore()
    {
        return score;
    }
}