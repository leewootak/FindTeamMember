using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;

    public Vector3 targetPos = Vector3.zero;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioManager.Instance.AddSFXInfo(audioSource);
    }

    public void Setting(int number)
    {
        idx = number;
        Sprite sprite = Resources.Load<Sprite>($"Sprites/teammate_{idx}");

        float originalX = sprite.bounds.size.x;
        float originalY = sprite.bounds.size.y;
        float originalRatio = originalY / originalX; // ������ ����

        float targetX = 0.9f; // ���ϴ� ���� ũ��
        float targetY = targetX * originalRatio;
        
        // ���ΰ� ū �̹��� ����
        if (targetY > 0.9f)
        {
            targetY = 0.9f;
            targetX = targetY * (originalX / originalY);
        }

        // ũ�� �ٸ� �̹����� ���߱� ����  
        float realX = targetX / originalX;
        float realY = targetY / originalY;
        front.transform.localScale = new Vector3(realX, realY, 1f);
        frontImage.sprite = sprite;
    }

    public void HiddenSetting(int number)
    {
        idx = number;
        //anim.SetInteger("HiddenCard", idx);
    }

    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null)
        {
            return;
        }

        audioSource.PlayOneShot(clip);
        front.SetActive(true);
        back.SetActive(false);
        anim.SetBool("isOpen", true);

        if (GameManager.Instance.CurLevel == 3)
        {
            Debug.Log($"{idx}");
            front.GetComponent<Animator>().SetInteger("HiddenCard", idx);
            
            //anim.SetInteger("HiddenCard", idx);
        }
        else
        {
            //anim.SetBool("isOpen", true);
        }

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }
    }

    public void DestroyCard()
    {
        if(GameManager.Instance.CurLevel == 3)
        {
            return; // ���� �������������� ī�� ���絵 ������� ���� 
        }
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        GameManager.Instance.CardList.Remove(this);
        AudioManager.Instance.SFXList.Remove(gameObject.GetComponent<AudioSource>());
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.8f);
    }

    void CloseCardInvoke()
    {
        front.GetComponent<Animator>().SetInteger("HiddenCard", -1);
        anim.SetBool("OpenCard", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
