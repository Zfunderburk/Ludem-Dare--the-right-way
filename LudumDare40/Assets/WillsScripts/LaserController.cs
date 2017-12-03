using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	public int laserDamage;
	public GameObject hitParticle;

	LineRenderer myLine;

	// Use this for initialization
	void Start () {
		myLine = GetComponent<LineRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3 (0, 0, Mathf.Atan2 (Input.GetAxis ("RightV"), Input.GetAxis ("RightH")) * -180 / Mathf.PI);
		HandleLaser ();
		hitParticle.transform.LookAt (transform.position);
	}

	void HandleLaser () {

		if (Input.GetAxis ("RightV") <= 0.19f && Input.GetAxis ("RightH") <= 0.19f) {
			myLine.enabled = false;
		} else {
			RaycastHit2D hit = Physics2D.Raycast (transform.TransformPoint(Vector3.zero), transform.TransformDirection(Vector3.right));
			myLine.enabled = true;
			myLine.SetPosition (0, new Vector3(0,0,0));
			if (hit.collider != null) {
				myLine.SetPosition (1, new Vector2(hit.distance, 0));
				hitParticle.transform.position = hit.point;
			} else {
				myLine.SetPosition(1, new Vector2 (500, 0));
				hitParticle.transform.position = new Vector3 (100, 100, 0);
			}
		}

	}
}