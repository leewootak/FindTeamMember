using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    float time = 0f;
    public Text timeTxt;
    public GameObject failTxt, clearTxt, normalSuccessPanel, hardSuccessPanel, board, pauseBtn;
    public float normalMaxTime = 60f;
    public float hardMaxTime = 100f;
    public Slider tSlider;
    public Hero hero;

    private Image sliderFill;

    private void Start()
    {
        Time.timeScale = 1f;
        if (GameManager.Instance.CurLevel == 1 || GameManager.Instance.CurLevel == 3)
        {
            tSlider.maxValue = normalMaxTime;
        }
        if (GameManager.Instance.CurLevel == 2)
        {
            tSlider.maxValue = hardMaxTime;
        }
        sliderFill = tSlider.fillRect.GetComponent<Image>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        tSlider.value = time;
        float t = Mathf.Clamp01(time / normalMaxTime);
        if (GameManager.Instance.CurLevel == 2)
        {
            t = Mathf.Clamp01(time / hardMaxTime);
        }

        sliderFill.color = Color.Lerp(Color.yellow, Color.red, t);
        timeTxt.color = Color.Lerp(Color.yellow, Color.red, t);

        // Normal 단계
        if (GameManager.Instance.CurLevel == 1)
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
                GameManager.Instance.NomarlClear = true;
            }

            // 실패
            else if (time >= normalMaxTime)
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
        else if(GameManager.Instance.CurLevel ==2)
        {
            // 성공
            if (GameManager.Instance.IsFinished)
            {
                clearTxt.SetActive(true);
                hardSuccessPanel.SetActive(true);
                timeTxt.enabled = false;
                board.SetActive(false);
                pauseBtn.SetActive(false);
                tSlider.gameObject.SetActive(false);
                AudioManager.Instance.SFXList.Clear();
                GameManager.Instance.HardClear = true;
            }

            // 실패
            else if (time >= hardMaxTime)
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
            // 성공
            if (GameManager.Instance.IsFinished)
            {
                clearTxt.SetActive(true);
                timeTxt.enabled = false;
                board.SetActive(false);
                pauseBtn.SetActive(false);
                tSlider.gameObject.SetActive(false);
                AudioManager.Instance.SFXList.Clear();

                hero.PlaySuccessAnim();

                Invoke("EndingSceneInvoke", 5.0f);
            }

            // 실패
            else if (time >= normalMaxTime)
            {
                failTxt.SetActive(true);
                timeTxt.enabled = false;
                board.SetActive(false);
                pauseBtn.SetActive(false);
                tSlider.gameObject.SetActive(false);
                AudioManager.Instance.SFXList.Clear();

                hero.PlayDeathAnim();
            }
        }
    }

    void EndingSceneInvoke()
    {
        GameManager.Instance.LoadScene("EndingScene");
    }

}
