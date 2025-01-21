using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Setting(int number)
    {
        idx = number;
        Sprite sprite = Resources.Load<Sprite>($"Sprites/teammate_{idx}");

        float originalX = sprite.bounds.size.x;
        float originalY = sprite.bounds.size.y;
        float originalRatio = originalY / originalX; // 사진의 원래 비율

        float targetX = 0.7f; // 원하는 가로 크기
        float targetY = targetX * originalRatio;
        front.transform.localScale = new Vector3(targetX / originalX, targetY / originalY, 1f);

        frontImage.sprite = sprite;
    }

    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null)
        {
            return;
        }

        audioSource.PlayOneShot(clip);
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

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
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.8f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
