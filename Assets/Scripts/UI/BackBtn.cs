using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackBtn : MonoBehaviour
{
    public void Back()
    {
        //SceneManager.LoadScene("StartScene");
        GameManager.Instance.LoadScene("StartScene");
    }
}
