using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {

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

//	void OnCollisionEnter2D(Collision2D hit)
//	{
//		if (hit.gameObject.name == "Top")
//		{
//			rb.AddForce(-(flotage + gravity)*1.5f* (times/5f) * transform.up , ForceMode2D.Impulse);
//			times--;
//		}
//	}

	void Update(){

//		
		//constant flotage
		rb.AddForce(transform.up * (flotage + gravity)  , ForceMode2D.Force);

		
		if (rb.position.x > 19.6 && rb.velocity.x > 0 ) {
			//left edge
			rb.AddForce(-(rb.velocity.x*rb.mass*1.5f) * transform.right , ForceMode2D.Impulse);
		}
		if (rb.position.x < -19.6 && rb.velocity.x < 0 ) {
			//right edge
			rb.AddForce(-(rb.velocity.x*rb.mass*1.5f) * transform.right , ForceMode2D.Impulse);
		}
		if (rb.position.y < -9.25 && rb.velocity.y < 0) {
			//bottom edge
			rb.AddForce(-(rb.velocity.y*rb.mass*1.5f) * transform.up , ForceMode2D.Impulse);

		}
		if (rb.position.y > 9.25 && rb.velocity.y > 0 ) {
			//top edge
			if (rb.velocity.y * rb.mass * 1.5f < (flotage + gravity)*0.05f) {
				rb.AddForce (-(flotage + gravity ) * (0.05f) * transform.up , ForceMode2D.Impulse);
			} else {
				rb.AddForce(-(rb.velocity.y*rb.mass*1.5f) * transform.up , ForceMode2D.Impulse);
			}

		}


//		if (Input.GetMouseButtonDown(0))
//		{
//			wind = 0.5f;
//		}
//		obj.transform.Translate(Vector3.right * Time.deltaTime);
	}
	void OnGUI()
	{
		if (Input.anyKeyDown)
		{
			Event e = Event.current;
			if (e.isKey)
			{

				//press key to control wind
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
