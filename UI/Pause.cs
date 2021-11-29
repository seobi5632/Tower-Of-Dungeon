using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public GameObject pauseManu;
    [SerializeField]
    private string click_sound;
    public void SetMusicVolume(float volume)
    {
        SoundManager.instance.audioSourceBGM.volume = volume;
    }

    public void SetSoundVolume(float volume)
    {
        for (int i = 0; i < SoundManager.instance.audioSourceEffects.Length; i++)
        {
            SoundManager.instance.audioSourceEffects[i].volume = volume;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseManu.SetActive(!pauseManu.activeSelf);
            GameManager.isPause = pauseManu.activeSelf;
        }
    }

    public void Exit()
    {
        pauseManu.SetActive(false);
        GameManager.isPause = false;
        SoundManager.instance.PlaySE(click_sound);
    }
}
