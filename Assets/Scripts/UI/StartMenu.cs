using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private GameObject hiddenLevelSelectMenu;
    [SerializeField] private GameObject optionMenu;

    private void Start()
    {
        UIManager.Instance.OpenUI(this.gameObject);
    }

    public void StartGame()
    {
        if (GameManager.Instance.Hidden)
        {
            UIManager.Instance.OpenUI(hiddenLevelSelectMenu);
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
