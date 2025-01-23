using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    float time = 0f;
    public Text timeTxt;
    public GameObject failTxt, clearTxt, normalSuccessPanel, hardSuccessPanel, board, pauseBtn;
    public float maxTime = 30f;
    public Slider tSlider;
    public Hero hero;

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
        float t = Mathf.Clamp01(time / maxTime);
        sliderFill.color = Color.Lerp(Color.yellow, Color.red, t);
        timeTxt.color = Color.Lerp(Color.yellow, Color.red, t);

        // Normal, Hard 단계
        if (GameManager.Instance.CurLevel == 1 || GameManager.Instance.CurLevel == 2)
        {
            // 성공
            if (GameManager.Instance.IsFinished)
            {
                clearTxt.SetActive(true);
                normalSuccessPanel.SetActive(true);
                timeTxt.enabled = false;
                board.SetActive(false);
                pauseBtn.SetActive(false);
                tSlider.gameObject.SetActive(false);

                AudioManager.Instance.SFXList.Clear();

                if (GameManager.Instance.CurLevel == 1)
                {
                    GameManager.Instance.NomarlClear = true;
                }
                else if (GameManager.Instance.CurLevel == 2)
                {
                    GameManager.Instance.HardClear = true;
                }
            }

            // 실패
            else if (time >= maxTime)
            {
                timeTxt.text = 30f.ToString("N2");
                Time.timeScale = 0f;
                failTxt.SetActive(true);
                timeTxt.enabled = false;
                board.SetActive(false);
                tSlider.gameObject.SetActive(false);
                pauseBtn.SetActive(false);
                AudioManager.Instance.SFXList.Clear();
            }
        }

        // Hidden 단계
        else if (GameManager.Instance.CurLevel == 3)
        {
            // 실패
            if (time >= maxTime)
            {
                failTxt.SetActive(true);
                timeTxt.enabled = false;
                board.SetActive(false);
                pauseBtn.SetActive(false);
                tSlider.gameObject.SetActive(false);
                AudioManager.Instance.SFXList.Clear();

                hero.PlayDeathAnim();
            }

            // 성공
            else if (GameManager.Instance.IsFinished)
            {
                clearTxt.SetActive(true);
                timeTxt.enabled = false;
                board.SetActive(false);
                pauseBtn.SetActive(false);
                tSlider.gameObject.SetActive(false);
                AudioManager.Instance.SFXList.Clear();
                
                hero.PlaySuccessAnim();
            }
        }
    }

}
