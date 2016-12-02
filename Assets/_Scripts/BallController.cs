using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float servePower;
	Rigidbody _ball;
	Vector3 originalPosition;
	Quaternion originalRotation;

	// Use this for initialization
	void Start () {
		_ball = GetComponent<Rigidbody> ();
		originalPosition = _ball.position;
		originalRotation = _ball.rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.R)) {
			ResetBall ();
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			// GetServeType ();
			ServeBall (createNormalServe());
		}
	}

	/*
	void GetServeType() {
		if (Input.GetKey (KeyCode.W)) {
			
		}
	}
	*/

	void ServeBall(NormalServe serve) {
		_ball.AddForce (transform.forward * serve.velocity);
		_ball.AddForce (transform.up * serve.trajectory);
		_ball.useGravity = true;
		Debug.Log (serve.velocity);
	}

	void ResetBall () {
		transform.position = originalPosition;
		transform.rotation = originalRotation;
		_ball.useGravity = false;
		_ball.velocity = Vector3.zero;
		_ball.angularVelocity = Vector3.zero;
	}


	private NormalServe createNormalServe() {
		return new NormalServe {
			velocity = Random.Range (100.0f, 150.0f),
			distance = Random.Range (500.0f, 550.0f),
			trajectory = Random.Range (100.0f, 125.0f),
			spinAxis = Quaternion.AngleAxis (30, Vector3.up)
		};
	}

	// Serve types

	private struct NormalServe {
		public float velocity;
		public float distance;
		public float trajectory;

		public Quaternion spinAxis;
	}

}
