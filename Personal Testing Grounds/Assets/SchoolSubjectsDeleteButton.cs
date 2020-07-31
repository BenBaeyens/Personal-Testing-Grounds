using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolSubjectsDeleteButton : MonoBehaviour
{

    public SchoolClasses currentClass;

    // Has to be called from another script
    public void Initialise()
    {
        transform.parent.GetChild(1).GetComponent<Text>().text = currentClass.displayString;
    }

    public void OnClick()
    {
        GameObject.Find("SchoolSubjects").GetComponent<SchoolSubjectsController>().DeleteSubject(currentClass.index);
    }
}
