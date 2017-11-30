using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitiesManager : MonoBehaviour 
{
	public City zeusCity, poseidonCity, athenaCity;
	public GameObject zeusAOE;

    public Unlocks unlocks; // TODO(Chris) Move this to some central location? or maybe just have other scripts reference. Honestly pretty good either way.

	void Update() 
	{
        if(unlocks.zeus.unlocked)
        {
            if(Input.GetKeyDown(unlocks.zeus.keycode))
            {
                float scaleMulti = unlocks.zeusBonus.unlocked ? unlocks.zeusBonus.bonus : 1;
                GameObject.Instantiate(zeusAOE).transform.localScale *= scaleMulti; // TODO(Chris) Imagine that this actually changes something mechanically
            }
        }
        
        if(unlocks.poseidon.unlocked)
        {

        }

        if(unlocks.athena.unlocked)
        {

        }

	}
}
