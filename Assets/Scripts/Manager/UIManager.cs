using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    private Stack<GameObject> uiStack;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("UIManager");
                    instance = obj.AddComponent<UIManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    public Stack<GameObject> UIStack => uiStack;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

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
