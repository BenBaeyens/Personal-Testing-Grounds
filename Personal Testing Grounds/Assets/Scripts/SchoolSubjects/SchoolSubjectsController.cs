using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SchoolClasses
{
    public string name;
    public int hour;
    public int minute;
    public string dayString;
    public int dayInt;
    public bool repeating;

    public GameObject Object;
    public string displayString;
    public int index;
}

public class SchoolSubjectsController : MonoBehaviour
{

    // Input Variables 
    public InputField SubjectField;

    // The time
    public Dropdown Hour1;
    public Dropdown Hour2_01; // The second hour dropdown, for hours 0x and 1x
    public Dropdown Hour2_2; // The second hour dropdown, for the hour 2x
    public Dropdown Minute1;
    public Dropdown Minute2;

    public Dropdown DayDropdown;
    public Toggle RepeatingToggle;

    public GameObject SubjectPrefab;
    public Transform PrefabParent;

    // Local Variables
    bool is01Active;

    public List<SchoolClasses> schoolClasses = new List<SchoolClasses>();

    private void Update()
    {

        if (Hour1.value == 2)
        {
            Hour2_2.gameObject.SetActive(true);
            Hour2_01.gameObject.SetActive(false);
            is01Active = false;
        }
        else
        {
            Hour2_2.gameObject.SetActive(false);
            Hour2_01.gameObject.SetActive(true);
            is01Active = true;
        }
    }

    public void AddButton()
    {
        schoolClasses.Add(new SchoolClasses());
        SchoolClasses currentClass = schoolClasses[schoolClasses.Count - 1];

        // TIME CALCULATION
        int finalHour = Hour1.value * 10; // Add the first hour hand to the finalhour.
        int finalminutes = Minute1.value * 10 + Minute2.value;

        if (is01Active)
        {
            finalHour += Hour2_01.value; // add the single digit hours to the finalhour variable via parsing
        }
        else
        {
            finalHour += Hour2_2.value; // same thing but with the other, limited dropdown menu
        }


        // Add the day string
        string day = "";
        switch (DayDropdown.value)
        {
            case 0:
                day = "Monday";
                break;
            case 1:
                day = "Tuesday";
                break;
            case 2:
                day = "Wednesday";
                break;
            case 3:
                day = "Thursday";
                break;
            case 4:
                day = "Friday";
                break;
            default:
                break;
        }

        // Assign all values
        currentClass.name = SubjectField.text;
        currentClass.hour = finalHour;
        currentClass.minute = finalminutes;
        currentClass.dayString = day;
        currentClass.dayInt = DayDropdown.value;
        currentClass.repeating = RepeatingToggle.isOn;
        currentClass.index = schoolClasses.Count - 1;
        currentClass.displayString = currentClass.name + " - " + currentClass.hour + ":" + currentClass.minute + " - " + currentClass.dayString;

        currentClass.Object = Instantiate(SubjectPrefab, PrefabParent);
        currentClass.Object.GetComponentInChildren<SchoolSubjectsDeleteButton>().currentClass = currentClass;
        currentClass.Object.GetComponentInChildren<SchoolSubjectsDeleteButton>().Initialise();
    }

    public void DeleteSubject(int index)
    {
        for (int i = 0; i < schoolClasses.Count; i++)
        {
            if (i > index)
            {
                schoolClasses[i].index--;
                schoolClasses[i].Object.GetComponentInChildren<SchoolSubjectsDeleteButton>().currentClass = schoolClasses[i];
            }
        }
        Destroy(schoolClasses[index].Object);
        schoolClasses.RemoveAt(index);
    }
}
