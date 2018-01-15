using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftInducedDrag : MonoBehaviour {

    // Use this for initialization
    public float gravity;
    public Rigidbody2D rb;
    public float Cl; 
    public float wingarea;
    public float enginepower;
    public float resistance;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = 30.0f;
        Cl = 1f;
        wingarea = 200.0f;
        enginepower=200.0f;
        resistance = -30f;


        rb.AddForce(transform.up * -gravity, ForceMode2D.Force);
        rb.AddForce(transform.up * Cl * wingarea * 0.5f * rb.velocity.y * rb.velocity.y, ForceMode2D.Force);
        rb.AddForce(transform.right * enginepower, ForceMode2D.Force);
        rb.AddForce(transform.right * resistance, ForceMode2D.Force);
       

    }
}

