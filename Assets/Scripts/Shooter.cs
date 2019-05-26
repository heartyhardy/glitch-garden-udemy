using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [Header("Weapon")]
    [SerializeField] GameObject weaponHand;
    [SerializeField] Projectile projectile;

    public void Fire()
    {
        var projectileInstance = Instantiate(
                projectile,
                weaponHand.transform.position,
                Quaternion.identity
            );
    }
}
