using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	// Slow panSpeed if holding Person?
	float panSpeed = 0.1f;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.mousePosition.x <= 0){
			transform.position += new Vector3(-panSpeed, 0, 0);
		} else if (Input.mousePosition.x >= Screen.width){
			transform.position += new Vector3(panSpeed, 0, 0);
		}

		if (Input.mousePosition.y <= 0){
			transform.position += new Vector3(0, -panSpeed, 0);
		} else if (Input.mousePosition.y >= Screen.height){
			transform.position += new Vector3(0, panSpeed, 0);
		}
	}
}
