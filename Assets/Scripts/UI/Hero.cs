using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour

{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance.CurLevel == 3)
        {
            GameManager.Instance.HiddenClear = true;
            anim.SetBool("isHSuccess", true);
        }
    }
}
