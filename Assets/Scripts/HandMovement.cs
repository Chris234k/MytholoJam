using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour {

    public Sprite open, close;

    public SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// If cursor is within screen boundaries, follow cursor
		if (Input.mousePosition.x > 0 && Input.mousePosition.x < Screen.width && Input.mousePosition.y > 0 && Input.mousePosition.y < Screen.height){
			transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
		} 
		// If cursor is off screen to top-left
		else if (Input.mousePosition.x <= 0 && Input.mousePosition.y >= Screen.height){
			Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
			Vector3 newPosition = new Vector3(screenToWorldPoint.x, screenToWorldPoint.y, transform.position.z);
			transform.position = newPosition;
		}
		// If cursor is off screen to top-right
		else if (Input.mousePosition.x >= Screen.width && Input.mousePosition.y >= Screen.height){
			Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
			Vector3 newPosition = new Vector3(screenToWorldPoint.x, screenToWorldPoint.y, transform.position.z);
			transform.position = newPosition;
		}
		// If cursor is off screen to bottom-left
		else if (Input.mousePosition.x <= 0 && Input.mousePosition.y <= 0){
			Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
			Vector3 newPosition = new Vector3(screenToWorldPoint.x, screenToWorldPoint.y, transform.position.z);
			transform.position = newPosition;
		}
		// If cursor is off screen to bottom-right
		else if (Input.mousePosition.x >= Screen.width && Input.mousePosition.y <= 0){
			Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
			Vector3 newPosition = new Vector3(screenToWorldPoint.x, screenToWorldPoint.y, transform.position.z);
			transform.position = newPosition;
		}
		// If cursor is off screen to right
		else if (Input.mousePosition.x >= Screen.width){
			Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
			Vector3 newPosition = new Vector3(screenToWorldPoint.x, mousePosition.y, transform.position.z);
			transform.position = newPosition;
		} 
		// If cursor is off screen to left
		else if (Input.mousePosition.x <= 0){
			Vector3 newPosition = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, mousePosition.y, transform.position.z);
			transform.position = newPosition;
		} 
		// If cursor is off screen to top
		else if (Input.mousePosition.y >= Screen.height){
			Vector3 newPosition = new Vector3(mousePosition.x, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y, transform.position.z);
			transform.position = newPosition;
		} 
		// If cursor is off screen to bottom
		else if (Input.mousePosition.y <= 0){
			Vector3 newPosition = new Vector3(mousePosition.x, Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y, transform.position.z);
			transform.position = newPosition;
		}


        if(Input.GetMouseButton(0))
        {
            rend.sprite = close;
        }
        else
        {
            rend.sprite = open;
        }
	}
}
