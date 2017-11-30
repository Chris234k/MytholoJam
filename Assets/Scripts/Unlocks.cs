using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocks : MonoBehaviour
{
    public Ability zeus, poseidon, athena;
    public StatBonus zeusBonus, poseidonBonus, athenaBonus;


    // TODO(Chris) Gross dude
    // Necessary activating from UnityEvent in SkillNode
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

// See AbilityDrawer
[System.Serializable]
public class Ability
{
    public bool unlocked;
    public KeyCode keycode;
}

// See StatBonusDrawer
[System.Serializable]
public class StatBonus
{
    public bool unlocked;
    public float bonus;
}