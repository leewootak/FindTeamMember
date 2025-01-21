using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSeclect : MonoBehaviour
{
    public void normal()
    {
        Debug.Log("노말 스테이지 진입");
        SceneManager.LoadScene("NormalScene");
    }

    public void hard()
    {
        Debug.Log("하드 스테이지 진입");
        SceneManager.LoadScene("HardScene");
    }

}
