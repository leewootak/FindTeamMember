using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour

{
    public bool isHiddenClear;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isHiddenClear == true)
        {
            anim.SetBool("isHSuccess", true);
        }
    }
}
