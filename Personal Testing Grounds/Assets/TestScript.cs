using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class TestScript : MonoBehaviour
{
    
}


[CustomEditor(typeof(TestScript))] [ExecuteInEditMode]
public class TestScriptEditor : Editor
{
    public enum Type{
        cube,
        sphere
    }

    public enum Amount{
        [Header("Test")]one,
        two,
        three,
        four
    }

    public static Type type = Type.cube;
    public static Amount amount = Amount.four;
    public List<object> testscripts = new List<object>();
   
    public object test4;
    public object test2;

    public static int numberofObjects;

    public override void OnInspectorGUI(){
        type = (Type)EditorGUILayout.EnumPopup("Type", type);
        amount = (Amount)EditorGUILayout.EnumPopup("Amount", amount);

        switch (amount)
        {
            case Amount.one:
                numberofObjects = 1;
                break;
            case Amount.two:
                numberofObjects = 2;
                switch (type){
                    case Type.cube:
                        test2 = EditorGUILayout.ObjectField(type.ToString() + amount.ToString(), (TestScript)test2, typeof(TestScript));
                        break;
                    case Type.sphere:
                        test2 = EditorGUILayout.ObjectField(type.ToString() + amount.ToString(), (TestScript)test2, typeof(TestScript));
                        break;
                }
                break;
            case Amount.three:
                numberofObjects = 3;
                break;
            case Amount.four:
                numberofObjects = 4;
                test4 = EditorGUILayout.ObjectField("Test", (GameObject)test4, typeof(GameObject));
                break;
            default:
                Debug.Log("No match found.. ..?");
                break;
        }

        if(GUILayout.Button("Generate Objects")){
            Debug.Log(test4);
            Debug.Log(test2);
        }
    }
}
