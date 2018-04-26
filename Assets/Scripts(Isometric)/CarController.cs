using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	private Rigidbody rb;


     public float speed;

     void Start () {
		rb = GetComponent<Rigidbody>();
	}	

	void FixedUpdate()
	{
	   	float moveHorizontal = Input.GetAxis ("Horizontal");
        	float moveVertical = Input.GetAxis ("Vertical");

        	Vector3 movement = new Vector3 (-moveVertical, -0.5f, moveHorizontal);
        	rb.velocity = movement*speed;
	}
}
