using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftInducedDrag : MonoBehaviour {

    public float gravity; 
    public Rigidbody2D rb;
    public float res; 
    public float push;
    public float lift;

    // Use this for initialization
    void Start()
    {

        gravity = -2f;
        rb = GetComponent<Rigidbody2D>();
        push = 10f;
        res = -5f;
        rb.AddForce(transform.up * gravity, ForceMode2D.Force);

    }

    // Update is called once per frame
    void Update()
    {

        
        lift = rb.velocity.x * 0.5f;
        rb.AddForce(transform.up * (gravity + lift), ForceMode2D.Force);

        rb.AddForce(transform.right * (push + res), ForceMode2D.Force);
    }
}

