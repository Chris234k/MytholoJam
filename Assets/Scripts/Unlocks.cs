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
        zeus.isUnlocked = true;
    }

    public void UnlockPoseidon()
    {
        poseidon.isUnlocked = true;
    }

    public void UnlockAthena()
    {
        athena.isUnlocked = true;
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
    public bool isUnlocked;
    public KeyCode keycode;
    public float cooldown;
    public float lastUsedTime;


    public bool IsAvailable(float currentTime)
    {
        bool result = false;

        if ( isUnlocked )
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