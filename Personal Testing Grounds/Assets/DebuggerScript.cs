using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerScript : MonoBehaviour
{
    public float TimeScaleAdjustment = 0.3f;
    public float SnapValueAdjustment = 0.1f;
    float originalSnapValue;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            if (Time.timeScale != 1)
                Time.timeScale = 1;
            else
                Time.timeScale = TimeScaleAdjustment;
            Debug.LogWarning("DEBUGGER: Time Scale has changed.");
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.LogWarning("DEBUGGER: All snap values have been changed");
            // Get all the objects
            SingleObjectSnap[] snapScripts = FindObjectsOfType<SingleObjectSnap>();
            originalSnapValue = snapScripts[0].smoothTime;

            if (snapScripts[0].smoothTime != SnapValueAdjustment)
            {
                foreach (SingleObjectSnap script in snapScripts)
                {
                    script.smoothTime = SnapValueAdjustment;
                }
            }
            else
            {
                foreach (SingleObjectSnap script in snapScripts)
                {
                    script.smoothTime = originalSnapValue;
                }
            }
        }
    }
}
