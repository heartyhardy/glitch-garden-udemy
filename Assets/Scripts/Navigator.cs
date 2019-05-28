using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour {

    [Header("Scenes")]
    [SerializeField] int previous;
    [SerializeField] int next;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadSetting()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadNext()
    {
        StartCoroutine(LoadScene(next));
    }

    public void LoadPrevious()
    {
        StartCoroutine(LoadScene(previous));
    }

    IEnumerator LoadScene(int buildIndex)
    {
        yield return new WaitForSeconds(2f);

        Time.timeScale = 1;
        SceneManager.LoadScene(buildIndex);
    }
}
