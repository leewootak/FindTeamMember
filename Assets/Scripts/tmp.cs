using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tmp : MonoBehaviour
{
    public Image image;
    private float fill;
    private float alpha;
    private Color col;

    private float targetTime;
    public float elpased;

    private void Awake()
    {
        fill = image.fillAmount;
        alpha = image.color.a;
        col = image.color;
        targetTime = 3f;
    }

    private void Update()
    {
        elpased += Time.deltaTime;
        image.fillAmount = Mathf.Lerp(0f, 1f, elpased / targetTime);
        alpha = Mathf.Lerp(0f, 1f, elpased / targetTime);
        col.a = alpha;
        image.color = col;
    }
}
