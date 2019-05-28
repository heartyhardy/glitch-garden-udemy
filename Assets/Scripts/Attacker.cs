using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    float movementSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().AttackerDestroyed();
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        UpdateAttackState();
	}

    private void UpdateAttackState()
    {
        if (!currentTarget)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile enemyProjectile = collision.gameObject.GetComponent<Projectile>();

        if (!enemyProjectile)
            return;
        else
            OnHitByProjectile(enemyProjectile);
    }

    private void OnHitByProjectile(Projectile projectile)
    {
        HealthPoints hp = GetComponent<HealthPoints>();
        hp.ReduceHP(projectile.getDamage());
        projectile.OnHit();
        PlayOnHitVFX(hp, projectile);

        if(hp.getCurrentHP() <= 0)
        {
            Die(hp, projectile);
        }
    }

    private void PlayOnHitVFX(HealthPoints hp, Projectile projectile)
    {
        GameObject onHit = Instantiate(
                    hp.getOnHitVFX(),
                    projectile.gameObject.transform.position,
                    projectile.gameObject.transform.rotation
                );
        Destroy(onHit, .5f);
    }



    private void Die(HealthPoints hp, Projectile projectile)
    {
        Destroy(gameObject);
        PlayOnDeathVFX(hp, projectile);
    }

    private void PlayOnDeathVFX(HealthPoints hp, Projectile projectile)
    {
        GameObject onHit = Instantiate(
            hp.getOnDeathVFX(),
            projectile.gameObject.transform.position,
            projectile.gameObject.transform.rotation
        );
        Destroy(onHit, .5f);
    }

    public void Attack(GameObject target)
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsAttacking", true);

        currentTarget = target;
    }

    public void StrikeTarget(float damage)
    {
        if (currentTarget)
        {
            Defender defender = currentTarget.GetComponent<Defender>();
            HealthPoints hp = currentTarget.GetComponent<HealthPoints>();

            if (hp)
            {
                hp.ReduceHP(damage);
                defender.Damaged(hp);

                if(hp.getCurrentHP() <= 0)
                {
                    defender.Die(hp);
                }
            }
        }
    }
}
