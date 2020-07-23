// Written by Ben Baeyens - https://www.benbaeyens.com/

// <summary>
// This script automatically snaps any component it's attached to to their corresponding values.
// </summary>

using UnityEngine;

[ExecuteInEditMode]
public class PathBlockerScript : MonoBehaviour
{

    private void Start()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Renderer>().enabled = false;
        }
    }
}