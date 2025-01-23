using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenBG : MonoBehaviour
{
    private Image image;

    private Color imageColor;

    private float elapsedTime;
    private float targetTime;

    private void Awake()
    {
        image = GetComponent<Image>();
        imageColor = image.color;

        elapsedTime = 0f;
        targetTime = 1f;
    }

    public void ActiveHidden()
    {
        if (GameManager.Instance.HiddenClear)
        {
            AudioManager.Instance.HiddenBGM();
            StartCoroutine(ActiveBackground());
        }
    }

    public IEnumerator ActiveBackground()
    {
        while (elapsedTime < targetTime)
        {
            elapsedTime += Time.deltaTime;
            imageColor.a = Mathf.Lerp(0f, 1f, elapsedTime / targetTime);
            image.color = imageColor;
            image.fillAmount = Mathf.Lerp(0.333f, 0.667f, elapsedTime / targetTime);
            yield return null;
        }
        imageColor.a = 1f;
        image.color = imageColor;
        image.fillAmount = 0.667f;
    }
}
