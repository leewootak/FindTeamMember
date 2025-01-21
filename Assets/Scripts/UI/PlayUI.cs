using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    float time = 0f;
    public Text timeTxt;
    public GameObject failTxt, clearTxt, normalSuccessPanel, hardSuccessPanel, board;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (GameManager.Instance.IsFinished)
        {
            clearTxt.SetActive(true);
            normalSuccessPanel.SetActive(true);
            timeTxt.enabled = false;
            board.SetActive(false);
            AudioManager.Instance.SFXList.Clear();
        }
        else if (time >= 30f)
        {
            timeTxt.text = 30f.ToString("N2");
            Time.timeScale = 0f;
            failTxt.SetActive(true);
            AudioManager.Instance.SFXList.Clear();
        }
    }
}
