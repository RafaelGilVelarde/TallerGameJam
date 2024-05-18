using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class OpcionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void FullScreen(bool fullcreen)
    {
        Screen.fullScreen = fullcreen;
    }

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

}


