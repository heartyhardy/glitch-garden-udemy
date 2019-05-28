using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SliderType
{
    Volume = 1,
    Difficutly =2
}

public class UISettingsLoader : MonoBehaviour {

    [SerializeField] PlayerSettingsLoader loader;
    [SerializeField] SliderType sliderType;
    Slider slider;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        LoadVolumeSettings();
	}
	
	// Update is called once per frame
	void Update () {
        ApplyVolumeSettings();
	}

    private void LoadVolumeSettings()
    {
        if(sliderType == SliderType.Volume)
        {
            slider.value = PlayerSettings.GetMasterVolume();
        }
    }

    private void ApplyVolumeSettings()
    {
        PlayerSettings.SetMasterVolume(slider.value);
        loader.SetMasterVolume();
    }

    public void SetDefaults()
    {
        PlayerSettings.setDefauls();
        LoadVolumeSettings();
    }
}
