using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Defender defender = collision.gameObject.GetComponent<Defender>();

        if (defender)
        {
            Gravestone gravestone = defender.GetComponent<Gravestone>();

            if (gravestone)
            {
                Jump();
            }
            else
            {
                Attacker attacker = GetComponent<Attacker>();
                attacker.Attack(collision.gameObject);
            }
        }
    }

    private void Jump()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Jumping");
    }

}
