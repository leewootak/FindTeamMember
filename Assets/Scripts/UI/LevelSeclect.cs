using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSeclect : MonoBehaviour
{
    public void NormalButton()
    {
        GameManager.Instance.CurLevel = eStageLevel.Easy;
        GameManager.Instance.LoadScene("MainScene");
    }

    public void HardButton()
    {
        GameManager.Instance.CurLevel = eStageLevel.Hard;
        GameManager.Instance.LoadScene("MainScene");
    }

    public void HiddenButton()
    {
        GameManager.Instance.CurLevel = eStageLevel.Hidden;
        GameManager.Instance.LoadScene("HiddenScene");
    }

    public void ReturnButton()
    {
        UIManager.Instance.CloseUI();
    }
}
