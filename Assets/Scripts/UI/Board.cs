using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Board : MonoBehaviour
{
    public GameObject card;

    bool isCardShuffleEnd = false;
    float shuffleTime = 3f;
    int totalCard = 20;

    private void Start()
    {
        // GameManager.Instance.CurLevel = 3;
        switch (GameManager.Instance.CurLevel)
        {
            case 1:
                totalCard = 20;
                break;
            case 2:
                totalCard = 30;
                break;
            case 3:             // ����� 
                totalCard = 16;
                break;
            default:
                totalCard = 20;
                break;
        }

        GameManager.Instance.CardList.Clear();

        int[] arr = new int[totalCard];
        for(int i = 0; i <  totalCard; i++)
        {
            arr[i] = i / 2;
        }
        arr = arr.OrderBy(x => Random.Range(0f, totalCard / 2)).ToArray(); // �̹��� ��ȣ ���� 

        for (int i = 0; i < totalCard; i++)
        {
            GameObject go = Instantiate(card, gameObject.transform); 
            Card newCard = go.GetComponent<Card>();
            if(GameManager.Instance.CurLevel == 3)
            {
                newCard.HiddenSetting(arr[i]);
            }
            else
            {
                newCard.Setting(arr[i]);
            }

            float x, y;
            GameManager.Instance.CardList.Add(newCard);
            if (GameManager.Instance.CurLevel == 1)
            {
                x = (i % 5) * 1.15f - 2.3f;
                y = (i / 5) * 1.15f - 2.8f;
            }
            else if (GameManager.Instance.CurLevel == 2)
            {
                x = (i % 5) * 1.15f - 2.3f;
                y = (i / 5) * 1.15f - 3.8f;
            }
            else
            {
                x = (i % 4) * 1.15f - 1.62f;
                y = (i / 4) * 1.15f - 2.8f;
            }
            newCard.targetPos = new Vector3(x, y, 0f);
        }

        GameManager.Instance.cardCount = arr.Length;
    }

    private void Update()
    {
        if(isCardShuffleEnd)
        {
            foreach (Card c in GameManager.Instance.CardList)
            {
                c.anim.SetBool("isMoveEnd", true); // CardIdle�� �Ѱ���
            }
            return;
        }
        shuffleTime -= Time.deltaTime;
        if(shuffleTime < 2.0f)
        {
            foreach (Card c in GameManager.Instance.CardList)
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
}
