using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour
{
    private GameObject optionMenu;

    public void OptionButton()
    {
        UIManager.Instance.OpenUI(optionMenu);
    }

    public void ReturnButton()
    {
        UIManager.Instance.CloseUI();
    }
}
