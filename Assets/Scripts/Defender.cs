using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {
    [Header("Cost")]
    [SerializeField] int starCost = 100;

    public float getStarCost()
    {
        return starCost;
    }
}
