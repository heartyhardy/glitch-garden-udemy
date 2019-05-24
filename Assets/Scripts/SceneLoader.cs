using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    int currentBuildIndex = 0;

    private void Start()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentBuildIndex <= 0)
            ++currentBuildIndex;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(++currentBuildIndex);
    }
}
