using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FricMover : MonoBehaviour {
    public int speed;
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float moveHorizaontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moment = new Vector3(moveHorizaontal, 0.0f, moveVertical);

        rb.AddForce(moment * speed);
    }
}
