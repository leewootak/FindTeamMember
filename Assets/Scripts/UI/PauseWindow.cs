using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour
{
    [SerializeField] private GameObject optionMenu;

    public void PauseButton()
    {
        UIManager.Instance.OpenUI(this.gameObject);
        GameManager.Instance.PauseGame();
    }

    public void OptionButton()
    {
        UIManager.Instance.OpenUI(optionMenu);
    }

    public void ReturnButton()
    {
        UIManager.Instance.CloseUI();
        GameManager.Instance.ResumeGame();
    }
}
