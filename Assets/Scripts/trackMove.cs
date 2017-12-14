using System.Collections;
using UnityEngine;

public class trackMove : MonoBehaviour {

	public uiManager ui;
	public float speed;
	Vector2 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!ui.gameOver) {
			offset = new Vector2 (0, Time.time * speed);

			GetComponent<Renderer> ().material.mainTextureOffset = offset;
		}
	}
}
