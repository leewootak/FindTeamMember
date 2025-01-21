using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    private Stack<GameObject> uiStack;

    public static UIManager Instance => instance;

    private void Awake()
    {
        instance = this;

        uiStack = new Stack<GameObject>();
    }

    public void OpenUI(GameObject newUI)
    {
        if (uiStack.Count > 0)
        {
            uiStack.Peek().SetActive(false);
        }
        newUI.SetActive(true);
        uiStack.Push(newUI);
    }

    public void CloseUI()
    {
        if (uiStack.Count > 0)
        {
            GameObject currentUI = uiStack.Pop();
            currentUI.SetActive(false);

            if (uiStack.Count > 0)
            {
                uiStack.Peek().SetActive(true);
            }
        }
    }
}
