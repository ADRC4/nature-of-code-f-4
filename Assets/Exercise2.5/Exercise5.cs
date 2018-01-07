using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise5 : MonoBehaviour
{

    // Use this for initialization
    public float gravity;
    public Rigidbody2D rb;
    public float c;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = 500.0f;
        c = 1f;
        rb.AddForce(transform.up * -gravity, ForceMode2D.Force);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Liquid")
        {
            rb.AddForce(transform.up * gravity * rb.mass, ForceMode2D.Force);
            rb.AddForce(transform.up * -c * rb.velocity.y * rb.velocity.y, ForceMode2D.Force);
        }
    }
}
