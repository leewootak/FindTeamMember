using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSeclect : MonoBehaviour
{
    public void normal()
    {
        Debug.Log("�븻 �������� ����");
        SceneManager.LoadScene("NormalScene");
    }

    public void hard()
    {
        Debug.Log("�ϵ� �������� ����");
        SceneManager.LoadScene("HardScene");
    }

}
