using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CalendarScript : MonoBehaviour
{

    public int birthYear;
    public int birthMonth;

    int monthsPassed;

    private void Start()
    {
        int yearsPassed = System.DateTime.Now.Year - birthYear;
        int monthsPassedInYear = System.DateTime.Now.Month - birthMonth;

        monthsPassed = yearsPassed * 12 + monthsPassedInYear;

        MonthScript[] months = transform.GetComponentsInChildren<MonthScript>();
        Debug.Log(months.Length);

        for (int i = 0; i < monthsPassed; i++)
        {
            if (i < months.Length)
                months[i].HasPassed();
        }
    }
}
