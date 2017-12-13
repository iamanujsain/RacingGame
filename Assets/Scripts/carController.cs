using System.Collections;
using UnityEngine;

public class carController : MonoBehaviour {

	public float carSpeed;
	public uiManager ui;
	public AudioManager am;

	bool currentPlatformAndroid = false;
	Rigidbody2D rb;

	void Awake() {

		rb = GetComponent<Rigidbody2D> ();

		#if UNITY_ANDROID
			currentPlatformAndroid = true;
		#else
			currentPlatformAndroid = false;
		#endif
	}

	Vector3 position;

	// Use this for initialization
	void Start () {
		am.carSound.Play ();
		position = transform.position;

		if (currentPlatformAndroid == true) {
			TouchMove ();
		} else {
			
		}
	}

	// Update is called once per frame
	void Update () {

		if (currentPlatformAndroid) {
			TouchMove ();
			//AcclerometerMove ();
		} else {
			position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;

			position.x = Mathf.Clamp (position.x, -2.16f, 2.16f);

			transform.position = position;
		}

		position = transform.position;
		position.x = Mathf.Clamp (position.x, -2.16f, 2.16f);
		transform.position = position;

	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy Car") {
			//Destroy (gameObject);
			gameObject.SetActive(false);
			ui.gameOverActivated ();
			am.carSound.Stop ();
		}
	}

	void TouchMove() {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			float middle = Screen.width / 2;
			if (touch.position.x < middle && touch.phase == TouchPhase.Began) {
				MoveLeft ();
			}
			if (touch.position.x > middle && touch.phase == TouchPhase.Began) {
				MoveRight ();
			}
		} else {
			SetVelocityZero ();
		}
	}

	/**void AcclerometerMove() {
		float x = Input.acceleration.x;
		if (x < -0.1f) {
			MoveLeft ();
		} else if (x > 0.1f) {
			MoveRight ();
		}
	}*/

	public void MoveLeft() {
		rb.velocity = new Vector2 (-carSpeed, 0);
	}

	public void MoveRight() {
		rb.velocity = new Vector2 (carSpeed, 0);
	}

	public void SetVelocityZero() {
		rb.velocity = Vector2.zero;
	}
}
