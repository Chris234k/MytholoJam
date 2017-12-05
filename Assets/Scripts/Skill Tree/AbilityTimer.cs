using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityTimer : MonoBehaviour
{
    public Ability ability;
    public StatBonus cdBonus;
    public Image fill;

    void Start()
    {
        fill.fillAmount = 0;
    }

    void Update()
    {
        if ( ability.isUnlocked )
        {
            float cdMulti = 1;
            if ( cdBonus != null )
            {
                if ( cdBonus.isUnlocked )
                {
                    cdMulti = cdBonus.value;
                }
            }

            fill.fillAmount = 1 - ( Time.time - ability.lastUsedTime ) / ( ability.cooldown * cdMulti );
        }
    }
}