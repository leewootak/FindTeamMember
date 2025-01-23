using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Animator anim;

    public void PlayDeathAnim()
    {
        anim.SetTrigger("Fail");
    }

    public void PlaySuccessAnim()
    {
        anim.SetTrigger("Success");
    }
}

