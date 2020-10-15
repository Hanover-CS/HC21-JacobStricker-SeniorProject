using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAsteroids : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddTorque(10);
    }
}
