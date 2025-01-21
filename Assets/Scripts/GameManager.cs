using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject endTxt;
    public GameObject pauseButton;

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;
    float time = 0f;

    // 일시정지 버튼
    public bool isPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 일시정지 버튼
        if (!endTxt.activeSelf && !isPaused)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");

            if (time >= 30f)
            {
                timeTxt.text = 30f.ToString("N2");
                Time.timeScale = 0f;
                endTxt.SetActive(true);
            }
        }

    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                Time.timeScale = 0f;
                endTxt.SetActive(true);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    //일시정지 버튼
    public void TogglePause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;

            pauseButton.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            isPaused = false;

            pauseButton.SetActive(false);
        }
    }
}
