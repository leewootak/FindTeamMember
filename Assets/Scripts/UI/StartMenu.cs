using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private GameObject optionMenu;

    private void Start()
    {
        UIManager.Instance.OpenUI(this.gameObject);
    }

    public void StartGame()
    {
        //SceneManager.LoadScene("MenuScene");
        UIManager.Instance.OpenUI(levelSelectMenu);
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
