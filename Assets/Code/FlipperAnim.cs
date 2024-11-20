using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperAnim : MonoBehaviour
{
    public Animator animator;
    public bool ON = false;

    void Start()
    {
        TurnedON();
    }
    public void SwitchONOFF()
    {
        if (ON)
        {
            TurnedON();
        }
        else
        {
            TurnedOff();
        }
    }

    void TurnedON()
    {
        animator.speed = 1.0f;
        ON = false;
    }
    void TurnedOff()
    {
        animator.speed = 0;
        ON = true;
    }

    
}
