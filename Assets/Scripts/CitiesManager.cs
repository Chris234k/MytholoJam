using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitiesManager : MonoBehaviour 
{
	public City[] cities;

	void Start() 
	{
		Helper.ShuffleGameObjects(cities);

		for (int i = 0; i < cities.Length; i++)
		{
			cities[i].alignment = (Alignment)i+1;
		}
	}
}
