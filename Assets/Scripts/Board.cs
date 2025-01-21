using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject card;
    public int curLevel = 1;    // 1:Normal, 2:Hard

    int totalCard = 20;

    private void Start()
    {
        // ���̵��� ���� ���� ����
        switch(curLevel)
        {
            case 1:
                totalCard = 20;
                break;
            case 2:
                totalCard = 30;
                break;
            default:
                totalCard = 20;
                break;
        }

        int[] arr = new int[totalCard];
        for(int i = 0; i <  totalCard; i++)
        {
            arr[i] = i / 2;
        }
        arr = arr.OrderBy(x => Random.Range(0f, totalCard / 2)).ToArray(); // �̹��� ��ȣ ���� 

        for (int i = 0; i < totalCard; i++)
        {
            Debug.Log(arr[i]);
            GameObject go = Instantiate(card, gameObject.transform);

            float x = (i % 5) * 1.1f - 2.17f;
            float y = (i / 5) * 1.1f - 3.3f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);
        }

        GameManager.Instance.cardCount = arr.Length;
    }
}
