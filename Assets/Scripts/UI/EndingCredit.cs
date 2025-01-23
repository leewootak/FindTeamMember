using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCredit : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] private GameObject returnBtn;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        AudioManager.Instance.endingBGM();
    }


    void Update()
    {
        rectTransform.localPosition += Vector3.down * Time.deltaTime * 100f;

        if (rectTransform.localPosition.y <= 0)
        {
            rectTransform.localPosition = Vector3.zero;
            returnBtn.SetActive(true);
        }
    }
}
