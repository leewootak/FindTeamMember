using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int idx;

    public GameObject front;
    [SerializeField] private GameObject back;

    public Animator anim;

    private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    public SpriteRenderer frontImage;

    public Vector3 targetPos;

    private Button btn;

    public Button Btn => btn;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        btn = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        AudioManager.Instance.AddSFXInfo(audioSource);
    }

    public void Initialize(int index, eStageLevel level)
    {
        idx = index;

        if (level != eStageLevel.Hidden)
        {
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
    }

    public void MoveCard(int index, eStageLevel level)
    {
        switch (level)
        {
            case eStageLevel.Easy:
                targetPos = new Vector3((index % 5) * 1.15f - 2.3f, (index / 5) * 1.15f - 2.8f, 0f);
                break;
            case eStageLevel.Hard:
                targetPos = new Vector3((index % 5) * 1.15f - 2.3f, (index / 5) * 1.15f - 3.8f, 0f);
                break;
            case eStageLevel.Hidden:
                targetPos = new Vector3((index % 4) * 1.15f - 1.62f, (index / 4) * 1.15f - 2.8f, 0f);
                break;
        }
    }

    public void OpenCard()
    {
        audioSource.PlayOneShot(clip);
        front.SetActive(true);
        back.SetActive(false);
        anim.SetBool("isOpen", true);
    }

    public void DestroyCard()
    {
        if (GameManager.Instance.CurLevel == eStageLevel.Hidden)
        {
            return; // ���� �������������� ī�� ���絵 ������� ���� 
        }
        Invoke("DestroyCardInvoke", 0.5f);
    }

    private void DestroyCardInvoke()
    {
        AudioManager.Instance.SFXList.Remove(gameObject.GetComponent<AudioSource>());
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.8f);
    }

    private void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        if (GameManager.Instance.CurLevel == eStageLevel.Hidden)
        {
            front.GetComponent<Animator>().SetInteger("HiddenCard", -1);
        }

        front.SetActive(false);
        back.SetActive(true);
        GameManager.Instance.isInteractable = true;
    }

    //public void tmpCloseCard()
    //{
    //    anim.SetBool("isOpen", false);
    //    if (GameManager.Instance.CurLevel == eStageLevel.Hidden)
    //    {
    //        front.GetComponent<Animator>().SetInteger("HiddenCard", -1);
    //    }

    //    front.SetActive(false);
    //    back.SetActive(true);
    //}
}
