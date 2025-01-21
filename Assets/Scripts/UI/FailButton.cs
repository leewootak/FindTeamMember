using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailButton : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("StartScene");
    }
}
