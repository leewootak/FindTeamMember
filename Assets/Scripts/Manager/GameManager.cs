using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int curLevel = 1;    // 1:Normal, 2:Hard, 3:Hidden

    AudioSource audioSource;
    public AudioClip clip;

    public Card firstCard;
    public Card secondCard;

    public int cardCount = 0;

    [SerializeField] private List<Card> cardList;

    private bool isFinished;

    [SerializeField] private bool normalClear = false;
    [SerializeField] private bool hardClear = false;

    public bool isAccessible = true;

    private bool hiddenClear = false;

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

    public bool HiddenClear
    {
        get => hiddenClear; set => hiddenClear = true;
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

    private void Update()
    {
        Debug.Log(cardList.Count);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        cardList.Clear();
        isFinished = false;
        if(scene.name == "StartScene" && normalClear == true && hardClear == true)
        {
            ActiveHidden();
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
        foreach (Card card in cardList)
        {
            Button btn = card.GetComponentInChildren<Button>();
            if (btn != null && btn.interactable == true)
            {
                btn.interactable = false;
            }
        }
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        foreach (Card card in cardList)
        {
            Button btn = card.GetComponentInChildren<Button>();
            if (btn != null && btn.interactable == false)
            {
                btn.interactable = true;
            }

        }
        Time.timeScale = 1f;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        cardList.Clear();
        UIManager.Instance.UIStack.Clear();
        AudioManager.Instance.SFXList.Clear();
    }

    public void ActiveHidden()
    {
        Debug.Log("플래그 활성화");
        HiddenClear = true;
        AudioManager.Instance.HiddenBGM();
    }
}
