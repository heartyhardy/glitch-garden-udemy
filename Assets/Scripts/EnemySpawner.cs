using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("Spawn attributes")]
    [SerializeField] Attacker enemy;

    [Header("Spawn Cooldown")]
    [SerializeField] [Range(1f, 2.5f)] float spawnCDMin = 1f;
    [SerializeField] [Range(2.5f, 5f)] float spawnCDMax = 2.5f;

    private bool isSpawning = true;

    // Use this for initialization
    IEnumerator Start()
    {
        while (isSpawning)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(spawnCDMin, spawnCDMax));
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(
            enemy,
            transform.position,
            transform.rotation
        );
    }

    // Update is called once per frame
    void Update()
    {

    }
}
