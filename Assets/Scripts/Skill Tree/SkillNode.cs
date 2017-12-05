﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Image), typeof(Button))]
public class SkillNode : MonoBehaviour
{
    Image localImage;
    Button localButton;

    static Color clrAvailable = Color.white,
        clrUnavailable = Color.black,
        clrUnlocked = Color.gray;

    public int points, required;
    public bool isUnlocked, isAvailable;

    public List<SkillNode> preReqs;

    public Material lineMat;

    public UnityEvent OnUnlock; // Respond to unlock via inspector reference. Just drag in what should happen on unlock.
    public static System.Action<SkillNode> OnNodeUnlocked;


    void Awake()
    {
        localImage = GetComponent<Image>();
        localButton = GetComponent<Button>();

        isAvailable = CheckAvailability();

        if ( isAvailable )
        {
            localImage.color = clrAvailable;
        }
        else
        {
            localImage.color = clrUnavailable;
            localButton.interactable = false;

            OnNodeUnlocked += AnyNodeUnlocked; // Listen for any node to be unlocked. Only really care if one of my prereqs were unlocked
        }
    }

    public void AddPoint()
    {
        if ( isAvailable && !isUnlocked )
        {
            points++;
            if ( points >= required )
            {
                Unlock();
            }
        }
    }

    void Unlock()
    {
        OnNodeUnlocked -= AnyNodeUnlocked; // I'm unlocked, don't listen any longer

        isUnlocked = true;

        localImage.color = clrUnlocked;
        localButton.interactable = false;

        if ( OnUnlock != null )
        {
            OnUnlock.Invoke();
        }

        if ( OnNodeUnlocked != null )
        {
            OnNodeUnlocked(this);
        }
    }

    bool CheckAvailability()
    {
        bool allUnlocked = true;

        for ( int i = 0; i < preReqs.Count; i++ )
        {
            if ( !preReqs[i].isUnlocked )
            {
                allUnlocked = false;
                break;
            }
        }

        return allUnlocked;
    }

    void AnyNodeUnlocked(SkillNode node) // Unlock event listener
    {
        isAvailable = CheckAvailability();

        localButton.interactable = isAvailable;

        if ( isAvailable )
        {
            localImage.color = clrAvailable;
        }
        else
        {
            localImage.color = clrUnavailable;
        }
    }

    void OnRenderObject() // oh boy
    {
        UnityEngine.Profiling.Profiler.BeginSample("Skill Tree Lines");
        for ( int i = 0; i < preReqs.Count; i++ )
        {
            GL.PushMatrix();
            lineMat.SetPass(0);
            //GL.LoadIdentity();
            //GL.MultMatrix(Camera.main.cameraToWorldMatrix); // The correct solution is not to specify any matrix ??
            GL.Begin(GL.LINES); // TODO(Chris) How to set render order on the lines (below canvas pls)
            GL.Color(Color.white);
            GL.Vertex(preReqs[i].transform.position);
            GL.Vertex(transform.position);
            GL.End();
            GL.PopMatrix();
        }
        UnityEngine.Profiling.Profiler.EndSample();
    }
}