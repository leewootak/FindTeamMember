using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private GameObject HiddenlevelSelectMenu;
    [SerializeField] private GameObject optionMenu;
    [SerializeField] private GameObject hiddenText;
    //[SerializeField] private GameObject hiddenBG;

    private void Start()
    {
        if (GameManager.Instance.HiddenClear)
        {
            hiddenText.SetActive(true);
        }
        UIManager.Instance.OpenUI(this.gameObject);
    }

    public void StartGame()
    {
        if (GameManager.Instance.HiddenClear)
        {
            UIManager.Instance.OpenUI(HiddenlevelSelectMenu);
        }
        else
        {
            UIManager.Instance.OpenUI(levelSelectMenu);
        }
        
    }

    public void DisplayOption()
    {
        UIManager.Instance.OpenUI(optionMenu);
    }

    public void ExitGame()
    {
        EditorApplication.ExitPlaymode();
    }
}
