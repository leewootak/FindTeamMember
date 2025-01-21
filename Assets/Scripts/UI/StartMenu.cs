using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionMenu;

    private void Start()
    {
        UIManager.Instance.OpenUI(this.gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MenuScene");
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
