using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BaseHP : MonoBehaviour {

    [Header("Base HP")]
    [SerializeField] int baseHP = 500;
    TextMeshProUGUI baseHpText;

	// Use this for initialization
	void Start () {
        baseHpText = GetComponent<TextMeshProUGUI>();
        updateText();
	}

    public void ReduceHP(int points)
    {
        baseHP -= (points > baseHP) ? baseHP : points;
        updateText();
        UpdateBaseState();
    }

    public void AddHP(int points)
    {
        baseHP += points;
        updateText();
    }

    private void updateText()
    {
        baseHpText.text = baseHP.ToString();
    }

    private void UpdateBaseState()
    {
        if(baseHP <= 0)
        {
            LevelController level = FindObjectOfType<LevelController>();

            if (!level.IsGameOver())
            {
                level.GameOver();
            }
        }
    }
}
