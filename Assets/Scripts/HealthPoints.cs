using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour {

    [Header("Health attributes")]
    [SerializeField] float maxHealthPoints = 200f;
    float healthPoints = 200f;

    [Header("Visual feedback")]
    [SerializeField] GameObject onHitVFX;
    [SerializeField] GameObject onDeathVFX;

    private void Start()
    {
        healthPoints = maxHealthPoints;
    }

    public void ReduceHP(float amount)
    {
        healthPoints -= (amount > healthPoints) ? healthPoints : amount;
    }

    public void IncreaseHP(float amount)
    {
        healthPoints += amount;
    }

    public float getCurrentHP()
    {
        return healthPoints;
    }

    public float getMaxHP()
    {
        return this.maxHealthPoints;
    }

    public GameObject getOnHitVFX()
    {
        return onHitVFX;
    }

    public GameObject getOnDeathVFX()
    {
        return onDeathVFX;
    }
}
