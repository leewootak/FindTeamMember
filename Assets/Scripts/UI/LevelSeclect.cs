using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSeclect : MonoBehaviour
{
    public void normal()
    {
        GameManager.Instance.CurLevel = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void hard()
    {
        GameManager.Instance.CurLevel = 2;
        SceneManager.LoadScene("MainScene");
    }

}
