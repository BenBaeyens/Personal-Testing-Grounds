using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyMapping : MonoBehaviour
{

    // Variables
    public TextMeshProUGUI KeyText; // The text that displays the key.
    public string remapMessage = "<PRESS A KEY>"; // The message that gets displayed upon remapping a key
    public KeyCode keyCode; // The assigned key

    public List<KeyCode> keyCodes = new List<KeyCode>();


    // Debugging messages
    public bool enableDebuggingMessages = false;
    string action; // The action of the key
    string noDefaultKeyMessage = "No default key set for action ";

    bool isRemapping;


    void Start()
    {
        // Debug
        action = transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        noDefaultKeyMessage = noDefaultKeyMessage + action + ".";

        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            keyCodes.Add(kcode);
        }

        if (keyCode != KeyCode.None)
            KeyText.text = keyCode.ToString().ToUpper();
        else
        {
            if (!System.Enum.TryParse<KeyCode>(KeyText.text.ToLower().FirstCharToUpper(), out keyCode))
            { // Parse the keycode with the given string already in place
                if (enableDebuggingMessages)
                    Debug.Log(this.GetType().Name + " : " + noDefaultKeyMessage);
            }
            else
            {
                KeyText.text = keyCode.ToString().ToUpper();
                if (enableDebuggingMessages)
                    Debug.Log(this.GetType().Name + " : " + action + " automatically mapped to: " + keyCode.ToString().ToUpper());
            }
        }
    }


    public void RemapKey()
    {
        KeyText.text = remapMessage;
        isRemapping = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode) && !isRemapping)
        {
            if (enableDebuggingMessages)
                Debug.Log(action);
        }

        if (isRemapping)
        {
            foreach (KeyCode kcode in keyCodes)
            {
                if (Input.GetKey(kcode))
                {
                    KeyText.text = kcode.ToString().ToUpper();
                    keyCode = kcode;
                    if (enableDebuggingMessages)
                        Debug.Log(this.GetType().Name + " : " + action + " remapped to: " + kcode.ToString().ToUpper());
                    isRemapping = false;
                }
            }
        }
    }
}
