using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper
{
	public static City[] ShuffleGameObjects(City[] array)
	{
		// Fisher-Yates shuffle
		for (int i = 0; i < array.Length; i++)
		{
			City temp = array[i];
			int index = Random.Range(i, array.Length);
			array[i] = array[index];
			array[index] = temp;
		}

		return array;
	}

	public static int RollDie(int sides)
	{
		return Random.Range(1, sides + 1);
	}
}
