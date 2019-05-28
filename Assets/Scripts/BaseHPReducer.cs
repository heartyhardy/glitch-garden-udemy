using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHPReducer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaseHP baseHP = FindObjectOfType<BaseHP>();
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            BaseDamager dmg = attacker.GetComponent<BaseDamager>();
            baseHP.ReduceHP(dmg.getBaseDamage());
            Destroy(collision.gameObject);
        }
    }
}
