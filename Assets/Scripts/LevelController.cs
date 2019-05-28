using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [Header("Messages")]
    [SerializeField] GameObject messageUI;

    [Header("Music")]
    [SerializeField] AudioClip winMusic;
    [SerializeField] AudioClip lostMusic;

    private int liveAttackers;
    private bool isLevelTimerExpired = false;
    private bool isGameLost = false;

    private void Start()
    {
        messageUI.SetActive(false);
    }

    public bool IsGameOver()
    {
        return isGameLost;
    }

    public void AttackerSpawned()
    {
        ++liveAttackers;
    }

    public void AttackerDestroyed()
    {
        --liveAttackers;
        updateLevelStatus();
    }

    public void LevelTimerExpired()
    {
        isLevelTimerExpired = true;
        StopAllSpawners();
    }

    private void StopAllSpawners()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();

        foreach(EnemySpawner spawner in spawners)
        {
            spawner.ShutdownSpawner();
        }
    }

    private void updateLevelStatus()
    {
        if(liveAttackers <= 0 && isLevelTimerExpired && !isGameLost)
        {
            StartCoroutine(ShowWinMessage());
        }
    }

    public void GameOver()
    {
        isGameLost = true;
        StartCoroutine(ShowLossMessage());
    }

    IEnumerator ShowLossMessage()
    {
        messageUI.GetComponentInChildren<GameMessage>().setText("Game Over!");
        messageUI.SetActive(true);
        messageUI.GetComponent<Animator>().SetBool("IsMessageShown", true);
        GetComponent<AudioSource>().clip = lostMusic;
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(10.5f);
        FindObjectOfType<Navigator>().LoadStartMenu();
    }

    IEnumerator ShowWinMessage()
    {
        messageUI.GetComponentInChildren<GameMessage>().setText("Level Complete!");
        messageUI.SetActive(true);
        messageUI.GetComponent<Animator>().SetBool("IsMessageShown", true);
        GetComponent<AudioSource>().clip = winMusic;
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        FindObjectOfType<Navigator>().LoadNext();
    }
}
