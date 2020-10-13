using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{

    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;
    
    //variables for screen wrapping
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    //variabels for asteroid destruction
    public int asteroidState;  // 3 = Large   2 = Medium  1 = Small     4 = small asteroid that spawns large   5 = medium asteroid that spawns a small and a respawning small
    public GameObject asteroidLarge;
    public GameObject asteroidMedium;
    public GameObject asteroidMediumRes;
    public GameObject asteroidSmall;
    public GameObject asteroidSmallRes;
    //somewhat random asteroid spawns
    public int xSpawn;
    public int ySpawn;

    //Scoring
    public GameObject player;
    public int scoreValue;

    //Sound
    public GameObject asteroidBreakingSound;

    // Start is called before the first frame update
    void Start()
    {
        //add random amount of force and torque based on max values
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        //apply forces to asteroid
        rb.AddForce(thrust);
        rb.AddTorque(torque);

        //set playerShip
        player = GameObject.FindWithTag("Player");
        asteroidBreakingSound = GameObject.FindWithTag("breakSound");
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //checks if collision is with laser
        //handle scoring
        if (other.CompareTag("laser"))
        {
            //adjust asteroid state
            if (asteroidState == 3)
            {
                //spawn 2 medium asteroids
                Instantiate(asteroidMedium, transform.position + new Vector3(1, 1, 0), transform.rotation);
                Instantiate(asteroidMediumRes, transform.position + new Vector3(-1, -1, 0), transform.rotation);
            }
            else if (asteroidState == 2 || asteroidState == 5)
            {
                Instantiate(asteroidSmall, transform.position + new Vector3(1, 1, 0), transform.rotation);
                Instantiate(asteroidSmallRes, transform.position + new Vector3(-1, -1, 0), transform.rotation);
            }
            else if (asteroidState == 4)
            {
                Instantiate(asteroidLarge, new Vector3(xSpawn, ySpawn, 0), transform.rotation);
            }
            //despawn laser and asteroid and add players points
            asteroidBreakingSound.SendMessage("playSound");
            player.SendMessage("ScorePoints", scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
