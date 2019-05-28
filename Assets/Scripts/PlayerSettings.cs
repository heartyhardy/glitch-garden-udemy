using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour {

    private const string MASTER_VOLUME_KEY = "master volume";
    private const string DIFFICULTY_KEY = "difficulty";
    private const string FIRST_RUN = "initial run";

    private const float MIN_VOLUME = 0f;
    private const float MAX_VOLUME = 1f;

    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
            Debug.Log(GetMasterVolume());
        }
            
    }

    public static void SetDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }

    public static bool isInitialRun()
    {
        int run = PlayerPrefs.GetInt(FIRST_RUN);

        if (run >= 0)
        {
            PlayerPrefs.SetInt(FIRST_RUN, -1);
            return true;
        }
        else if(run == -1)
        {
            return false;
        }
        else return false;
    }

    public static void setDefauls()
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, .5f);
        PlayerPrefs.SetInt(DIFFICULTY_KEY, 1);
    }
}
