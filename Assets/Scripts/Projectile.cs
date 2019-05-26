using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [Header("Projectile Attributes")]

    [Header("Movement")]
    [SerializeField] [Range(1f, 20f)] float speed = 1f;
    [SerializeField] [Range(360f, 7200f)] float rotation = 3600f;

    [Header("Damage")]
    [SerializeField] float damage = 100f;

    public float getSpeed()
    {
        return speed;
    }

    public float getDamage()
    {
        return damage;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * getSpeed() * Time.deltaTime,Space.World);
        transform.Rotate(Vector3.forward, rotation * Time.deltaTime,Space.World);
    }

    public void OnHit()
    {
        Destroy(gameObject);
    }
}
