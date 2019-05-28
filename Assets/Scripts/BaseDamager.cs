using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamager : MonoBehaviour {

    [Header("Base Damage")]
    [SerializeField] int baseDamage = 10;

    public int getBaseDamage()
    {
        return baseDamage;
    }
}
