using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotage : MonoBehaviour {

	public float wind;
	public float gravity;
	public float flotage;
	public Rigidbody2D rb;
	public GameObject obj; 
	public float times;

	// Use this for initialization
	void Start()
	{
		Vector3 v3 = new Vector3 (Screen.width, Screen.height);
		Debug.Log (v3);		
		Debug.Log (Camera.main.ScreenToViewportPoint(v3));		
		obj = GameObject.Find ("ball");
		rb = obj.GetComponent<Rigidbody2D>();
		flotage = 12.16f;
		gravity = -10.0f;
		wind = 0.5f;
		times = 5f;
	}

	void Update(){


		rb.AddForce(transform.up * (flotage + gravity)  , ForceMode2D.Force);
	}
	void OnGUI()
	{
		if (Input.anyKeyDown)
		{
			Event e = Event.current;
			if (e.isKey)
			{

				//keycode
				wind = Random.value * 2 + 1f;
				switch (e.keyCode) {
				case KeyCode.LeftArrow:
					rb.AddForce(-transform.right * wind, ForceMode2D.Impulse);
					break;
				case KeyCode.RightArrow:
					rb.AddForce(transform.right * wind, ForceMode2D.Impulse);
					break;
				case KeyCode.UpArrow:
					rb.AddForce(transform.up * wind, ForceMode2D.Impulse);
					break;
				case KeyCode.DownArrow:
					rb.AddForce(-transform.up * wind, ForceMode2D.Impulse);
					break;
				default:
					break;

				}
			}
		}
	}
}
