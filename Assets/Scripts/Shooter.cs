using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [Header("Weapon")]
    [SerializeField] GameObject weaponHand;
    [SerializeField] Projectile projectile;

    EnemySpawner laneSpawner;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        SetLaneSpawner();
    }

    private void Update()
    {
        if (AttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            bool isInProximity = Mathf.Abs(transform.position.y - spawner.transform.position.y + .5f) <= Mathf.Epsilon;

            if (isInProximity)
            {
                laneSpawner = spawner;
                break;
            }
        }
    }

    public bool AttackerInLane()
    {
        if (laneSpawner.transform.childCount > 0)
            return true;
        else return false;
    }

    public void Fire()
    {
        var projectileInstance = Instantiate(
                projectile,
                weaponHand.transform.position,
                Quaternion.identity
            );
    }
}
