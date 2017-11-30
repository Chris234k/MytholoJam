using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocks : MonoBehaviour
{
    public Ability zeus, poseidon, athena;
    public StatBonus zeusBonus, poseidonBonus, athenaBonus; // Successive unlocks can modify StatBonus.value rather than having numerous stat bonus classes


    // TODO(Chris) Gross dude
    // Necessary in activating from UnityEvent via SkillNode
    public void UnlockZeus()
    {
        zeus.unlocked = true;
    }

    public void UnlockPoseidon()
    {
        poseidon.unlocked = true;
    }

    public void UnlockAthena()
    {
        athena.unlocked = true;
    }

    public void UnlockZeusBonus()
    {
        zeusBonus.unlocked = true;
    }

    public void UnlockPoseidonBonus()
    {
        poseidonBonus.unlocked = true;
    }

    public void UnlockAthenaBonus()
    {
        athenaBonus.unlocked = true;
    }
}

[System.Serializable] // See AbilityDrawer
public class Ability
{
    public bool unlocked;
    public KeyCode keycode;
    public float cooldown;
    public float lastUsedTime;


    public bool CanBeCast(float currentTime)
    {
        bool result = false;

        if ( unlocked )
        {
            if ( Input.GetKeyDown(keycode) )
            {
                if ( currentTime - lastUsedTime >= cooldown ) // simple cooldown timer
                {
                    result = true;
                }
            }
        }

        return result;
    }
}


[System.Serializable] // See StatBonusDrawer
public class StatBonus
{
    public bool unlocked;
    public float value;
}