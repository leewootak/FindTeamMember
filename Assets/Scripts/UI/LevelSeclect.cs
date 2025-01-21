using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSeclect : MonoBehaviour
{
    public void normal()
    {
        SceneManager.LoadScene("NormalScene");
    }

    public void hard()
    {
        SceneManager.LoadScene("HardScene");
    }

}
