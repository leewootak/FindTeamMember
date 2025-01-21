using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    [Serializable]
    public struct Pair
    {
        public Slider slider;
        public Text figure;
    }

    [SerializeField] private Pair masterVol;
    [SerializeField] private Pair bgmVol;
    [SerializeField] private Pair sfxVol;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        masterVol.slider.value = AudioManager.Instance.MasterVol;
        masterVol.figure.text = (masterVol.slider.value * 100f).ToString("N0");

        bgmVol.slider.value = AudioManager.Instance.BgmVol;
        bgmVol.figure.text = (bgmVol.slider.value * 100f).ToString("N0");

        sfxVol.slider.value = AudioManager.Instance.SFXVol;
        sfxVol.figure.text = (sfxVol.slider.value * 100f).ToString("N0");
    }

    public void ChangeMasterVolume()
    {
        AudioManager.Instance.ChangeMasterVolume(masterVol.slider.value);
        masterVol.figure.text = (masterVol.slider.value * 100f).ToString("N0");
    }

    public void ChangeBGMVolume()
    {
        AudioManager.Instance.ChangeBGMVolume(bgmVol.slider.value);
        bgmVol.figure.text = (bgmVol.slider.value * 100f).ToString("N0");
    }

    public void ChangeSFXVolume()
    {
        AudioManager.Instance.ChangeSFXVolume(sfxVol.slider.value);
        sfxVol.figure.text = (sfxVol.slider.value * 100f).ToString("N0");
    }
}
