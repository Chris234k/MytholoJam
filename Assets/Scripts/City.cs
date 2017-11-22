﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class City : MonoBehaviour
{
    public int divinity;
    public Text display;

    public GameObject movingTextPrefab;
    public Canvas canvas;
	public Alignment alignment;

	bool thresholdReached;

    const string textFormat = "Divinity: {0}";

    void Start()
    {
        divinity = 0;
        display.text = string.Format(textFormat, divinity);
        thresholdReached = false;
    }

    void Update()
    {
    	if (divinity >= 15 && thresholdReached == false)
    	{
			this.GetComponentInParent<CitiesManager>().SendMessage("UnlockAbility", this, SendMessageOptions.DontRequireReceiver);
			thresholdReached = true;
    	}
    }

    void OnCitizenDropped(Citizen citizen)
    {
    	string divinityOperation;
    	Color textColor;
		
    	if (citizen.alignment == (Alignment)0 || alignment == citizen.alignment)
		{
        	divinity += citizen.holiness;
			divinityOperation = "+";
        	textColor = new Color(0, 0, 255);
    	}
    	else 
    	{
    		divinity -= citizen.holiness;
			divinityOperation = "-";
        	textColor = new Color(255, 0, 0);
    	}

        display.text = string.Format(textFormat, divinity);

        MovingText movText = GameObject.Instantiate(movingTextPrefab, canvas.transform, false).GetComponent<MovingText>();

        movText.Setup(
			string.Format("{0} {1}{2}", alignment, divinityOperation, citizen.holiness.ToString()),
			textColor,
            Camera.main.ScreenToWorldPoint(Input.mousePosition));

        Destroy(citizen.gameObject);
    }
}