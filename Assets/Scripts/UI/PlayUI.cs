using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    float time = 0f;
    public Text timeTxt;
    public GameObject failTxt, clearTxt, normalSuccessPanel, hardSuccessPanel, board;
    public float maxTime = 30f;
    public Slider tSlider;
    private Image sliderFill;

    private void Start()
    {
        Time.timeScale = 1f;
        tSlider.maxValue = maxTime;
        sliderFill = tSlider.fillRect.GetComponent<Image>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        tSlider.value = time;
        float t = Mathf.Clamp01(time / maxTime); // time을 0~1 사이 값으로 변환
        sliderFill.color = Color.Lerp(Color.white, Color.red, t);
        timeTxt.color = Color.Lerp(Color.white, Color.red, t);

        if (GameManager.Instance.IsFinished)
        {
            clearTxt.SetActive(true);
            normalSuccessPanel.SetActive(true);
            timeTxt.enabled = false;
            board.SetActive(false);
            AudioManager.Instance.SFXList.Clear();
        }
        else if (time >= 30f)// test용 10초 원래 30초
        {
            timeTxt.text = 30f.ToString("N2");
            Time.timeScale = 0f;
            failTxt.SetActive(true);
            timeTxt.enabled = false;
            board.SetActive(false);
            tSlider.gameObject.SetActive(false);
            AudioManager.Instance.SFXList.Clear();
        }
    }
}
