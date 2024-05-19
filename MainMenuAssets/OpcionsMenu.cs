using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OpcionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer MainMixer, SFXMixer;
    [SerializeField] float MainVolume, SFXVolume;
    [SerializeField] Slider MainSlider, SFXSlider;

    public void FullScreen(bool fullcreen)
    {
        Screen.fullScreen = fullcreen;
    }

    public void ChangeVolume()
    {
        MainVolume=MainSlider.value;
        SFXVolume=SFXSlider.value;
        MainMixer.SetFloat("Volume", Mathf.Log(MainVolume) * 20);
        SFXMixer.SetFloat("Volume", Mathf.Log(MainVolume)*20);
    }

}


