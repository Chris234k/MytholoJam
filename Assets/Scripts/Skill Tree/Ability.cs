using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public bool isUnlocked;
    public KeyCode keycode;
    public float cooldown;
    [HideInInspector]
    public float lastUsedTime;

    public void Unlock() // For use with UnityEvents. Intended for SkillNode.
    {
        isUnlocked = true;
    }


    public bool AttemptUse(float currentTime) // Most basic check to see if the ability should be used this frame
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