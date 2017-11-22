using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class City : MonoBehaviour
{
    int divinity;
    public Text display;

    public GameObject movingTextPrefab;
    public Canvas canvas;
	public Alignment alignment;

    const string textFormat = "Divinity: {0}";

    void Start()
    {
        divinity = 0;
        display.text = string.Format(textFormat, divinity);
    }

    void OnCitizenDropped(Citizen citizen)
    {
    	string divinityOperation;
    	Color textColor;

    	if (alignment == citizen.alignment)
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
			string.Format("{0} {1}{2}", citizen.alignment.ToString(), divinityOperation, citizen.holiness.ToString()),
			textColor,
            Camera.main.ScreenToWorldPoint(Input.mousePosition));

        Destroy(citizen.gameObject);
    }
}