using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject playerCar;
	private Vector3 offSet;
	// Use this for initialization
	void Start () {
		offSet = transform.position - playerCar.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = playerCar.transform.position + offSet;
	}
}
