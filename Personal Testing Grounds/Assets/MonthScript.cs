using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonthScript : MonoBehaviour
{

    public void HasPassed()
    {
        transform.GetComponent<RawImage>().color = Color.red;
    }
}
