using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider[] volumeSliders;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("LoadAudioSettings", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //save the updated audio settings to the save file
    public void SaveAudioSettings()
    {
        mainMixer.GetFloat("MasterVolume", out float a);
        mainMixer.GetFloat("BGMVolume", out float b);
        mainMixer.GetFloat("SFXVolume", out float c);
        //SaveManager.allVolumes = new float[3] { a, b, c };
        //SaveManager.Save(SaveManager.CreateGameSavedData());
    }

    //load the audio settings saved in the save file
    //public void LoadAudioSettings()
    //{
    //    float[] savedVolume = SaveManager.allVolumes;
    //    mainMixer.SetFloat("MasterVolume", savedVolume[0]);
    //    mainMixer.SetFloat("BGMVolume", savedVolume[1]);
    //    mainMixer.SetFloat("SFXVolume", savedVolume[2]);
    //    for (int i = 0; i < volumeSliders.Length; i++)
    //    {
    //        volumeSliders[i].value = savedVolume[i];
    //    }

    //}

    //update the master volume
    public void SetMasterVolume(float volume)
    {
        mainMixer.SetFloat("MasterVol", volume);
    }

    //update the background music volume
    public void SetBGMVolume(float volume)
    {
        mainMixer.SetFloat("BGMVol", volume);
    }

    //update the sound effect volume
    public void SetSFXVolume(float volume)
    {
        mainMixer.SetFloat("SFXVol", volume);
    }

}
