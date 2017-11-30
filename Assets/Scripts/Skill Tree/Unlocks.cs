using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocks : MonoBehaviour
{
    // TODO(Chris) eh?
    // These are really just data classes ... except for the isUnlocked field
    // ... ScriptableObjects sound almost perfect
    //
    public Ability zeus, poseidon, athena;
    public StatBonus zeusSpeed, poseidonBonus, athenaBonus; // Successive unlocks can modify StatBonus.value rather than having numerous stat bonus classes

    public static Unlocks instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}