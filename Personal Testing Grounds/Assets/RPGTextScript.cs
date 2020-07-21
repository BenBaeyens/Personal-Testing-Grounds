using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPGTextScript : MonoBehaviour
{

    public Text displayText;
    public string NPCName;
    public float textSpeed = .5f;

    [TextArea]
    public string dialogue;

    bool isTalking;
    public float currentChar = 0;

    private void Start() {
        displayText.text = NPCName + ": ";
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.B)){
            isTalking = true;
            currentChar = 0;
        }

        if(isTalking){
            if(currentChar >= dialogue.Length)
                isTalking = false;
            else{
                displayText.text = NPCName + ": " + dialogue.Substring(0, (int)currentChar +1);
                currentChar += textSpeed * Time.deltaTime;
            }
        }
    }
}