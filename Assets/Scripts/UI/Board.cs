using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject card;

    private List<Card> cardList;

    private Card firstCard;
    private Card secondCard;

    private bool isCardShuffleEnd;
    private float shuffleTime;
    private int totalCard;

    private AudioSource audioSource;
    public AudioClip mathchedClip;

    private void Awake()
    {
        cardList = new List<Card>();

        isCardShuffleEnd = false;
        shuffleTime = 3f;
        totalCard = 20;

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        AudioManager.Instance.AddSFXInfo(audioSource);

        int[] arr = new int[totalCard];
        for (int i = 0; i < totalCard; i++)
        {
            arr[i] = i / 2;
        }
        arr = arr.OrderBy(x => Random.Range(0f, totalCard / 2)).ToArray();

        for (int i = 0; i < totalCard; i++)
        {
            GameObject obj = Instantiate(card, gameObject.transform);
            Card newCard = obj.GetComponent<Card>();
            Button button = obj.GetComponentInChildren<Button>();
            button.onClick.AddListener(() => OpenCard(newCard));
            newCard.Initialize(arr[i], GameManager.Instance.CurLevel);
            newCard.MoveCard(i, GameManager.Instance.CurLevel);
            cardList.Add(newCard);
        }
    }

    private void Update()
    {
        if (isCardShuffleEnd)
        {
            foreach (Card c in cardList)
            {
                c.anim.SetBool("isMoveEnd", true);
            }
            return;
        }
        shuffleTime -= Time.deltaTime;
        if (shuffleTime < 2.0f)
        {
            foreach (Card c in cardList)
            {
                Vector3 targetPosition = c.targetPos;
                c.gameObject.transform.position = Vector3.Lerp(c.gameObject.transform.position, targetPosition, 0.01f);
                if (shuffleTime <= 0f)
                {
                    c.gameObject.transform.position = targetPosition;
                    isCardShuffleEnd = true;
                }
            }
        }
    }

    public void OpenCard(Card openedCard)
    {
        if (secondCard != null)
        {
            return;
        }

        openedCard.OpenCard();

        if (GameManager.Instance.CurLevel == eStageLevel.Hidden)
        {
            openedCard.front.GetComponent<Animator>().SetInteger("HiddenCard", openedCard.idx);
        }

        if (firstCard == null)
        {
            firstCard = openedCard;
        }
        else
        {
            secondCard = openedCard;
            Matched();
        }
    }

    private void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(mathchedClip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardList.Remove(firstCard);
            cardList.Remove(secondCard);
            if (cardList.Count == 0)
            {
                GameManager.Instance.IsFinished = true;
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
}
