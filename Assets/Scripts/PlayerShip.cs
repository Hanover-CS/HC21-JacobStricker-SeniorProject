using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //variables for the alternate screen wrapping implementation
/*
    Renderer[] renderers;
    bool isWrappingX = false;
    bool isWrappingY = false;
*/


    // Start is called before the first frame update
    void Start()
    {
        //renderer for alt - screen wrapping implementation
        //renderers = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //forward and rotational movement
       forwardInput = 0;
       if (Input.GetKey(KeyCode.W) || Input.GetButton("joy1"))
       {
           forwardInput = 1;
       }
       rotationInput = Input.GetAxis("Horizontal");

       //screen wrapping
        Vector2 newPos = transform.position;
        if(transform.position.y > screenTop)
        {
            newPos.y = screenBottom;
        }

        if(transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }

        if(transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }

        if(transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }

        transform.position = newPos;

        //Fire laser
        if (Input.GetButtonDown("fireLaser"))
        {
            GameObject newLaser = Instantiate(laser, laserEmitter.position, laserEmitter.rotation);
            newLaser.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * laserThrust);
            Destroy (newLaser, 4.0f);
        }
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce (Vector2.up * forwardInput * forward);
        rb.AddTorque (-rotationInput * rotation);
    }

//Working on implementing a new form of screen wrapping
//that will allow for different sized screens
/*
    bool CheckRenderers()
    {
        foreach(var renderer in renderers)
        {
            if(renderer.isVisible)
            {
                return true;
            }
        }
        return false;
    }

    void ScreenWrap()
    {
        var isVisible = CheckRenderers();
        if (isVisible)
        {
            isWrappingX = false;
            isWrappingY = false;
            return;
        }

        if(isWrappingX && isWrappingY)
        {
            return;
        }

        var cam = Camera.main;
        var viewportPosition = cam.WorldToViewPoint(transform.posiiton);
        var newPosition = transform.position;

        if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.x = -newPosition.x;
            isWrappingY = true;
        }

        if (!isWrapping && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.y = -newPosition.y;
            isWrappingY = true;
        }
        transform.position = newPosition;
    }
    */
}