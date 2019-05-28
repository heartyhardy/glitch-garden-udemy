using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Header("Game Time")]
    [Tooltip("Set the time that the user should fight on until its expired")]
    [SerializeField] float levelTime = 30f;
    bool isExpired = false;
	
	// Update is called once per frame
	void Update () {

        bool isGameLost = FindObjectOfType<LevelController>().IsGameOver();

        if (!isExpired && !isGameLost)
        {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

            bool isTimeExpired = Time.timeSinceLevelLoad >= levelTime;

            if (isTimeExpired)
            {
                FindObjectOfType<LevelController>().LevelTimerExpired();
                isExpired = true;
            }
        }
        else return;
	}
}
