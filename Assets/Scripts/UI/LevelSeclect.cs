using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSeclect : MonoBehaviour
{
    public void NormalButton()
    {
        GameManager.Instance.CurLevel = 1;
        //SceneManager.LoadScene("MainScene");
        GameManager.Instance.LoadScene("MainScene");
    }

    public void HardButton()
    {
        GameManager.Instance.CurLevel = 2;
        //SceneManager.LoadScene("MainScene");
        GameManager.Instance.LoadScene("MainScene");
    }

    public void HiddenButton()
    {
        GameManager.Instance.CurLevel = 3;
        GameManager.Instance.LoadScene("HiddenScene");
    }

    public void ReturnButton()
    {
        UIManager.Instance.CloseUI();
    }
}
