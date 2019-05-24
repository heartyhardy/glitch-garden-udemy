using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuLoader : MonoBehaviour {

    private const float LOAD_DELAY = 3f;

    IEnumerator Start()
    {
        Cursor.visible = false;
        yield return new WaitForSeconds(LOAD_DELAY);
        SceneManager.LoadScene("StartMenu");
        Cursor.visible = true;
    }
}
