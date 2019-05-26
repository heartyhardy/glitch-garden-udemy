using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour {
    [Header("Defender")]
    [SerializeField] Defender selectedDefender;

    [Header("Button State")]
    [SerializeField] bool isEnabled = false;
    [SerializeField] Color32 enabledColor;
    [SerializeField] Color32 disabledColor;

    private void Start()
    {
        SetButtonStatus();
    }

    public void Enable()
    {
        isEnabled = true;
    }

    public void Disable()
    {
        isEnabled = false;
    }

    public bool getButtonStatus()
    {
        return isEnabled;
    }

    public void SetButtonStatus()
    {
        if (isEnabled)
            setEnabledColor(enabledColor);
        else
            setDisabledColor(disabledColor);
    }

    private void OnMouseDown()
    {
        bool copyStatus = isEnabled;

        DisableAll();
        isEnabled = (copyStatus) ? false : true;

        SetButtonStatus();
        SelectDefender(selectedDefender);
    }

    private void SelectDefender(Defender selectedDefender)
    {
        DefenderSpawner spawner = FindObjectOfType<DefenderSpawner>();
        spawner.SelectDefender(selectedDefender);
    }

    private void setEnabledColor(Color32 color)
    {
        enabledColor = color;
        GetComponent<SpriteRenderer>().color = enabledColor;
    }

    private void setDisabledColor(Color32 color)
    {
        disabledColor = color;
        GetComponent<SpriteRenderer>().color = disabledColor;
    }

    public void DisableAll()
    {
        foreach(DefenderButton button in FindObjectsOfType<DefenderButton>())
        {
            button.Disable();
            button.SetButtonStatus();
        }
    }
}
