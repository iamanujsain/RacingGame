using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarMove : MonoBehaviour {

	public float speed = 5f;

	Vector3 position;

	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, 1, 0) * speed * Time.deltaTime);

		position = transform.position;
		position.x = Mathf.Clamp (position.x, -2.16f, 2.16f);
		transform.position = position;
	}
}
