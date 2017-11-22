using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitiesManager : MonoBehaviour 
{
	public City zeusCity, poseidonCity, athenaCity;
	public GameObject zeusAOE;

	bool zeusAbilityUnlocked, poseidonAbilityUnlocked, athenaAbilityUnlocked;

	void Update() 
	{
		if (Input.GetKeyDown("z") && zeusAbilityUnlocked)
    	{
    		GameObject.Instantiate(zeusAOE);
    	}
	}

	void UnlockAbility(City city)
	{
		switch (city.alignment)
		{
			case Alignment.Zeus: 
				zeusAbilityUnlocked = true; 
				break;
			case Alignment.Poseidon: 
				poseidonAbilityUnlocked = true;
				break;
			case Alignment.Athena: 
				athenaAbilityUnlocked = true;
				break;
		}
	}
}
