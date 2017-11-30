using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBonus : MonoBehaviour
{
    public bool isUnlocked;
    public float value;

    public void Unlock() // For use with UnityEvents. Intended for SkillNode.
    {
        isUnlocked = true;
    }
}