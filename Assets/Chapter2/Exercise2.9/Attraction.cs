using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public Transform BigTarget;
    public Transform SmallTarget;
    public Rigidbody2D rb;

    void Start()
    {
        GameObject Big = GameObject.Find("Big");
        BigTarget = Big.transform;

    }

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        SmallTarget = transform;
        rb.AddForce(transform.forward * 100, ForceMode2D.Force);
        rb.AddForce(transform.up * 100, ForceMode2D.Force);

    }



    void Update()
    {
        Vector3 line = BigTarget.position - SmallTarget.position;
        line.Normalize();

        float distance = Vector3.Distance(BigTarget.position, SmallTarget.position);
        rb.AddForce(line * 10 / distance);


    }


}
