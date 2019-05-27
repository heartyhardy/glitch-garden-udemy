using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Defender defender = collision.gameObject.GetComponent<Defender>();

        if (defender)
        {
            Attacker attacker = GetComponent<Attacker>();
            attacker.Attack(collision.gameObject);
        }
    }

}
