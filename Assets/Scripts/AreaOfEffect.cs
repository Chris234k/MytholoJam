using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : MonoBehaviour 
{

	void OnEnable() {

		CircleCollider2D collider = GetComponent<CircleCollider2D>();
		var overlapped = Physics2D.OverlapCircleAll(collider.bounds.center, collider.radius);

		for (int i = 0; i < overlapped.Length; i++) 
		{
			if (overlapped[i].name.Contains("Citizen")) 
			{
				// Convert to Zeus
				overlapped[i].gameObject.SendMessage("OnConvert", 1, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
