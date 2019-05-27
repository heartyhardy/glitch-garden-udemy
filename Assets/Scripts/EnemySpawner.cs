using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("Spawn attributes")]
    [SerializeField] Attacker enemy;

    [Header("Spawn Cooldown")]
    [SerializeField] [Range(1f, 5f)] float spawnCDMin = 2.5f;
    [SerializeField] [Range(5f, 30f)] float spawnCDMax = 5f;

    [SerializeField] bool isSpawning = false;

    [Header("Spawn Delay")]
    [SerializeField][Range(5f, 360f)] float initialDelay = 10f;

    bool isDelayed = true;

    // Use this for initialization
    IEnumerator Start()
    {
        yield return new WaitForSeconds(initialDelay);
        isDelayed = false;
        StartCoroutine(WaitAndSpawn());
    }

    IEnumerator WaitAndSpawn()
    {
        while (isSpawning)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(spawnCDMin, spawnCDMax));
        }
    }

    private void SpawnEnemy()
    {
        Attacker attacker = Instantiate(
            enemy,
            transform.position,
            transform.rotation
        );

        attacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
