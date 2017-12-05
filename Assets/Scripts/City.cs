using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class City : MonoBehaviour
{
    public int divinity;
    public int health;
    public Text display;

    public GameObject movingTextPrefab;
    public Canvas canvas;
	public Alignment alignment;

	bool thresholdReached;

    public static Dictionary<Alignment, int> scores; // For reference from the game over scene. Reset on Start.

    const string textFormat = "{0}: {1}";

    void Start()
    {
        scores = new Dictionary<Alignment, int>();
        scores.Add(Alignment.Athena, 0);
        scores.Add(Alignment.Poseidon, 0);
        scores.Add(Alignment.Zeus, 0);

        divinity = 5;
        display.text = string.Format(textFormat, alignment, divinity);
        thresholdReached = false;
    }

    void Update()
    {
    	
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

			if (divinity >= 15 && thresholdReached == false)
	    	{
				this.GetComponentInParent<CitiesManager>().SendMessage("UnlockAbility", this, SendMessageOptions.DontRequireReceiver);
				thresholdReached = true;
	    	}
    	}
    	else 
    	{
    		divinity -= citizen.holiness;
			divinityOperation = "-";
        	textColor = new Color(255, 0, 0);
    	}

		CreateMovingText(textColor, divinityOperation, citizen.holiness);

        Destroy(citizen.gameObject);
    }

    void OnEnemyAttack(Enemy enemy)
    {
    	divinity -= enemy.power;

		if (divinity < 0)
    	{
    		display.transform.parent.gameObject.SetActive(false);
    		gameObject.SetActive(false);
    	}

		CreateMovingText(new Color(255, 0, 0), "-", enemy.power);
    }

    void CreateMovingText(Color textColor, string operation, int amount)
    {
		display.text = string.Format(textFormat, alignment, divinity);

        scores[alignment] = divinity;

        MovingText movText = Instantiate(movingTextPrefab, canvas.transform, false).GetComponent<MovingText>();

        movText.Setup(
			string.Format("{0} {1}{2}", alignment, operation, amount.ToString()),
			textColor,
			transform.position);
    }
}