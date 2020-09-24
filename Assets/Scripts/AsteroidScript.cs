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
    public int asteroidState;  // 3 = Large   2 = Medium  1 = Small
    public GameObject asteroidMedium;
    public GameObject asteroidSmall;

    // Start is called before the first frame update
    void Start()
    {
        //add random amount of force and torque based on max values
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        //apply forces to asteroid
        rb.AddForce(thrust);
        rb.AddTorque(torque);
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
        if (other.CompareTag("laser"))
        {
            //adjust asteroid state
            if (asteroidState == 3)
            {
                //spawn 2 medium asteroids
                Instantiate(asteroidMedium, transform.position + new Vector3(2, 2, 0), transform.rotation);
                Instantiate(asteroidMedium, transform.position + new Vector3(-2, -2, 0), transform.rotation);
            }
            else if (asteroidState == 2)
            {
                Instantiate(asteroidSmall, transform.position + new Vector3(1, 1, 0), transform.rotation);
                Instantiate(asteroidSmall, transform.position + new Vector3(-1, -1, 0), transform.rotation);
            }
            //despawn laser and asteroid
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
