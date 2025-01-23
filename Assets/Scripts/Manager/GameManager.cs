using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum eStageLevel
{
    Easy,
    Hard,
    Hidden
}

public class GameManager : MonoBehaviour
{
    #region Variables
    private static GameManager instance;

    private eStageLevel curLevel;

    private bool isFinished;
    private bool normalClear;
    private bool hardClear;
    private bool hiddenClear;

    public bool isInteractable = true;
    #endregion

    #region Prperties
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    public eStageLevel CurLevel
    {
        get => curLevel; set => curLevel = value;
    }

    public bool NomarlClear
    {
        get => normalClear; set => normalClear = true;
    }

    public bool HardClear
    {
        get => hardClear; set => hardClear = true;
    }

    public bool HiddenClear
    {
        get => hiddenClear; set => hiddenClear = true;
    }

    public bool IsFinished
    {
        get => isFinished; set => isFinished = value;
    }
    #endregion

    #region Unity Event Method
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

        curLevel = eStageLevel.Easy;

        isFinished = false;
        normalClear = false;
        hardClear = false;
        hiddenClear = false;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    #endregion

    #region Private Method
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isFinished = false;
        if(scene.name == "StartScene" && normalClear == true && hardClear == true)
        {
            ActiveHidden();
        }
    }
    #endregion

    #region Public Method
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        UIManager.Instance.UIStack.Clear();
        AudioManager.Instance.SFXList.Clear();
    }

    public void ActiveHidden()
    {
        Debug.Log("플래그 활성화");
        HiddenClear = true;
        AudioManager.Instance.HiddenBGM();
    }
    #endregion
}
