using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCredit : MonoBehaviour
{
    RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    void Update()
    {
        rectTransform.localPosition += Vector3.down * Time.deltaTime * 100f;

        if (rectTransform.localPosition.y <= 0)
        {
            rectTransform.localPosition = Vector3.zero;
        }
    }
}
