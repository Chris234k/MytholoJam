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
        if ( unlocks.zeus.IsAvailable(Time.time) )
        {
            unlocks.zeus.lastUsedTime = Time.time;

            float scaleMulti = unlocks.zeusBonus.unlocked ? unlocks.zeusBonus.value : 1;
            GameObject.Instantiate(zeusAOE).transform.localScale *= scaleMulti; // TODO(Chris) Imagine that this actually changes something mechanically
        }

        if ( unlocks.poseidon.IsAvailable(Time.time) )
        {
            unlocks.poseidon.lastUsedTime = Time.time;

        }

        if ( unlocks.athena.IsAvailable(Time.time) )
        {
            unlocks.athena.lastUsedTime = Time.time;

        }
    }
}