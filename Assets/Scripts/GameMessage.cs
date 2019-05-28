using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMessage : MonoBehaviour {

    TextMeshProUGUI messageText;

    private void Start()
    {
        messageText = GetComponent<TextMeshProUGUI>();
    }

    public void setText(string text)
    {
        messageText.text = text;
    }

    public string getText()
    {
        return messageText.text;
    }
}
