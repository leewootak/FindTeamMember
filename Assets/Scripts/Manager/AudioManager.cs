using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource bgm;
    public AudioClip clip;
    public AudioClip hiddenClip;

    private List<AudioSource> sfxList;

    private float masterVol;
    private float bgmVol;
    private float sfxVol;

    public float MasterVol => masterVol;
    public float BgmVol => bgmVol;
    public float SFXVol => sfxVol;
    public List<AudioSource> SFXList => sfxList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        masterVol = 0.8f;
        bgmVol = 0.1f; // test¿ë 0.1f ¿ø·¡ 0.8f
        sfxVol = 0.8f;

        bgm = GetComponent<AudioSource>();
        bgm.clip = clip;
        bgm.volume = bgmVol * masterVol;

        sfxList = new List<AudioSource>();
    }

    private void Start()
    {
        bgm.Play();
    }

    public void ChangeMasterVolume(float figure)
    {
        masterVol = figure;
        bgm.volume = bgmVol * masterVol;
        for (int i = 0; i < sfxList.Count; i++)
        {
            sfxList[i].volume = sfxVol * masterVol;
        }
    }

    public void ChangeBGMVolume(float figure)
    {
        bgmVol = figure;
        bgm.volume = bgmVol * masterVol;
    }

    public void ChangeSFXVolume(float figure)
    {
        sfxVol = figure;
        for (int i = 0; i < sfxList.Count; i++)
        {
            sfxList[i].volume = sfxVol * masterVol;
        }
    }

    public void AddSFXInfo(AudioSource audio)
    {
        if (!sfxList.Contains(audio))
        {
            sfxList.Add(audio);
            audio.volume = sfxVol * masterVol;
        }
    }
    public void HiddenBGM()
    {
        if (bgm.clip.name != hiddenClip.name)
        {
            bgm.clip = hiddenClip;
            bgm.Play();
        }
        
    }
}
