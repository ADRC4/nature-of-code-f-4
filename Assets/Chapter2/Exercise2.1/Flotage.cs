using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotage : MonoBehaviour
{

    public float wind;
    public float gravity;
    public float flotage;
    public Rigidbody2D rb;
    public GameObject obj;


    // Use this for initialization
    void Start()
    {
        Vector3 v3 = new Vector3(Screen.width, Screen.height);
        Debug.Log(v3);
        Debug.Log(Camera.main.ScreenToViewportPoint(v3));
        obj = GameObject.Find("ball");
        rb = obj.GetComponent<Rigidbody2D>();
        flotage = 12.16f;
        gravity = -10.0f;
        wind = 1.0f;
    }

    void Update()
    {


        rb.AddForce(transform.up * (flotage + gravity), ForceMode2D.Force);
        obj.transform.Translate(Vector3.right * wind * Time.deltaTime);
        if (rb.position.y > 4.5 && rb.velocity.y > 0)
        {
            //top edge
            if (rb.velocity.y * rb.mass * 1.5f < (flotage + gravity) * 0.05f)
            {
                rb.AddForce(-(flotage + gravity) * (0.05f) * transform.up, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(-(rb.velocity.y * rb.mass * 1.5f) * transform.up, ForceMode2D.Impulse);
            }

        }
    }
}
   
    
