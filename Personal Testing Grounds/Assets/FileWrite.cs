using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[ExecuteInEditMode]
public class FileWrite : MonoBehaviour
{
    public string writePath = "Assets/Resources/Salary.txt";
    public string wagesPath = "Assets/Resources/Wages.txt";
    public string employeesPath = "Assets/Resources/Employees.txt";
    public string hoursWorkedPath = "Assets/Resources/HoursWorked.txt";


    [Header("WRITE BUTTON:")]
    public bool write = false;

    private void Update()
    {
        if (write)
        {
            write = false;
            FileWriter.WriteString(wagesPath, employeesPath, hoursWorkedPath, writePath);
        }
    }
}
