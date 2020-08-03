using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class FileWriter
{
    [MenuItem("Tools/Write file")]
    public static void WriteString(string wagesPath, string employeesPath, string hoursWorkedPath, string salaryPath)
    {

        //Write some text to the test.txt file

        int Lines = File.ReadAllLines(wagesPath).Length;
        StreamReader wagesReader = new StreamReader(wagesPath);
        StreamReader employeesReader = new StreamReader(employeesPath);
        StreamReader hoursWorkedReader = new StreamReader(hoursWorkedPath);
        StreamWriter salaryWriter = new StreamWriter(salaryPath);


        List<float> values = new List<float>();
        for (int i = 0; i < Lines; i++)
        {
            values.Add(float.Parse(wagesReader.ReadLine()) * float.Parse(hoursWorkedReader.ReadLine()));
            salaryWriter.Write("");
            salaryWriter.WriteLine(employeesReader.ReadLine() + " - " + values[i]);
        }

        wagesReader.Close();
        employeesReader.Close();
        hoursWorkedReader.Close();
        salaryWriter.Close();
    }
}