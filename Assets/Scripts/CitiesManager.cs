using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitiesManager : MonoBehaviour
{
    public City zeusCity, poseidonCity, athenaCity;
    public GameObject zeusAOE;

    void Update()
    {
        Unlocks unlocks = Unlocks.instance;

        if ( unlocks.zeus.isUnlocked ) // Custom usage, since there is a speed power up.
        {
            if(Input.GetKeyDown(unlocks.zeus.keycode))
            {
                float speedMulti = unlocks.zeusSpeed.isUnlocked ? unlocks.zeusSpeed.value : 1;

                if (Time.time - unlocks.zeus.lastUsedTime >= (unlocks.zeus.cooldown * speedMulti))
                {
                    unlocks.zeus.lastUsedTime = Time.time;

                    GameObject.Instantiate(zeusAOE);
                }
            }
        }

        if ( unlocks.poseidon.AttemptUse(Time.time) )
        {
            unlocks.poseidon.lastUsedTime = Time.time;

        }

        if ( unlocks.athena.AttemptUse(Time.time) )
        {
            unlocks.athena.lastUsedTime = Time.time;

        }
    }
}