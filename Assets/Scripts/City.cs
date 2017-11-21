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

    const string textFormat = "Divinity: {0}";

    void Start()
    {
        divinity = 0;
        display.text = string.Format(textFormat, divinity);
    }

    void OnCitizenDropped(Citizen citizen)
    {
        divinity += citizen.holiness;
        display.text = string.Format(textFormat, divinity);

        MovingText movText = GameObject.Instantiate(movingTextPrefab, canvas.transform, false).GetComponent<MovingText>();

        movText.Setup(
            string.Format("{0} +{1}", citizen.alignment.ToString(), citizen.holiness.ToString()),
            Camera.main.ScreenToWorldPoint(Input.mousePosition));

        Destroy(citizen.gameObject);
    }
}