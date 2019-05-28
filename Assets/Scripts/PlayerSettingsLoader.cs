using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettingsLoader : MonoBehaviour {

    private void Awake()
    {
        if (PlayerSettings.isInitialRun())
        {
            PlayerSettings.setDefauls();
            SetMasterVolume();
        }
        else
        {
            SetMasterVolume();
        }
    }

    public void SetMasterVolume()
    {
        AudioSource source = GetComponent<AudioSource>();
        AudioSource[] childSources = GetComponentsInChildren<AudioSource>();

        source.volume = PlayerSettings.GetMasterVolume();

        if(childSources.Length > 0)
        {
            foreach(AudioSource audioSource in childSources)
            {
                audioSource.volume = PlayerSettings.GetMasterVolume();
            }
        }
    }

}
