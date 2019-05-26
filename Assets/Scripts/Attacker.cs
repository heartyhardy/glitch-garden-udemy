using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    float movementSpeed = 1f;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
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
}
