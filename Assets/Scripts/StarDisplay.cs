using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StarDisplay : MonoBehaviour {

    [Header("Star points")]
    [SerializeField] int stars = 100;

    TextMeshProUGUI starText;

    private void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
        updateStars();
    }

    public void AddStars(int points)
    {
        stars += points;
        updateStars();
    }

    public void ReduceStars(int points)
    {
        stars -= (stars >= points) ? points : 0;
        updateStars();
    }

    public int getStars()
    {
        return stars;
    }

    private void updateStars()
    {
        starText.text = stars.ToString();
    }
}
