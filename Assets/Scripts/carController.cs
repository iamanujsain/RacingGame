using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class carController : MonoBehaviour {

	public uiManager ui;
	public AudioManager am;
    	public carSpawner cp;

    	float carSpeed = 2.5f;
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

        if (uiManager.score > 20 && uiManager.score < 50)
        {
            trackMove.speed = .4f;
            EnemyCarMove.speed = 3f;
            cp.delayTimer = 1.3f;
            carSpeed = 2.7f;
        }
        else if (uiManager.score > 50 && uiManager.score < 100)
        {
            trackMove.speed = .7f;
            EnemyCarMove.speed = 5f;
            cp.delayTimer = 1f;
            carSpeed = 3f;
        }
        else if (uiManager.score > 100)
        {
            trackMove.speed = 1f;
            EnemyCarMove.speed = 7f;
            cp.delayTimer = .75f;
            carSpeed = 3f;
        }

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

            carSpeed = 2.5f;
            trackMove.speed = .2f;
            EnemyCarMove.speed = 3f;
		}
	}

	void TouchMove() {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			float middle = Screen.width / 2;
			float fp = Screen.height - 100f;

			if (touch.position.y < fp) {
				if (touch.position.x < middle && touch.phase == TouchPhase.Began) {
					MoveLeft ();
				} else if (touch.position.x > middle && touch.phase == TouchPhase.Began)  {
					MoveRight ();
				}
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
