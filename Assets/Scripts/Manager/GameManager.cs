using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int curLevel = 1;    // 1:Normal, 2:Hard

    AudioSource audioSource;
    public AudioClip clip;

    public Card firstCard;
    public Card secondCard;

    public int cardCount = 0;

    private List<Card> cardList;

    private bool isFinished;

    private bool normalClear = false;
    private bool hardClear = false;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    public int CurLevel
    {
        get => curLevel; set => curLevel = value;
    }

    public bool NomarlClear
    {
        get => normalClear; set => normalClear = true;
    }

    public bool HardClear
    {
        get => hardClear; set => hardClear = true;
    }

    public List<Card> CardList => cardList;

    public bool IsFinished => isFinished;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

        cardList = new List<Card>();
    }

    private void Start()
    {
        Time.timeScale = 1f;
        isFinished = false;

        audioSource = GetComponent<AudioSource>();
        AudioManager.Instance.AddSFXInfo(audioSource);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIManager.Instance.UIStack.Clear();
        cardList.Clear();
        isFinished = false;
        if(scene.name == "StartScene" && normalClear == true && hardClear == true)
        {
            Debug.Log("플래그 활성화");
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
                isFinished = true;
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

    public void PauseGame()
    {
        Time.timeScale = 0f;
        foreach (Card card in cardList)
        {
            card.GetComponentInChildren<Button>().enabled = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        foreach (Card card in cardList)
        {
            card.GetComponentInChildren<Button>().enabled = true;
        }
    }
}
