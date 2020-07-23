using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathfindScript))]
[ExecuteInEditMode]
public class PathfindScriptEditor : Editor
{

    PathfindScript pathfindScript;
    bool showHandles;

    Vector3 tempPointOffset;



    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        pathfindScript = (PathfindScript)target;

        showHandles = EditorGUILayout.Toggle("Show Handles", showHandles);

        if (GUILayout.Button("Generate New Point"))
        {
            pathfindScript.pathPoints.Add(new Vector3(0, 0, 0) + pathfindScript.transform.position + pathfindScript.pathOffset);
        }

        if (GUILayout.Button("Calibrate Points"))
        {
            for (int i = 0; i < pathfindScript.pathPoints.Count; i++)
            {
                tempPointOffset = pathfindScript.pathPoints[i];
                // FIX
                pathfindScript.pathPoints[i] = Vector3.zero - tempPointOffset + pathfindScript.pathPoints[i] + pathfindScript.pathOffset;
            }
        }

        if (GUILayout.Button("Generate Path Blockers"))
        {
            pathfindScript.GeneratePathBlockers();
        }

        if (GUILayout.Button("RESET PATH"))
        {
            pathfindScript.pathPoints.Clear();
        }



    }

    private void OnSceneGUI()
    {
        pathfindScript = (PathfindScript)target;
        if (pathfindScript.showPath && showHandles)
        {
            for (int i = 0; i < pathfindScript.pathPoints.Count; i++)
            {
                EditorGUI.BeginChangeCheck();
                Vector3 targetPos = Handles.PositionHandle(pathfindScript.pathPoints[i], pathfindScript.transform.rotation);

                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(pathfindScript, "Change path");
                    pathfindScript.pathPoints[i] = targetPos;
                }
            }
        }
    }
}



public class PathfindScript : MonoBehaviour
{

    public List<Vector3> pathPoints = new List<Vector3>(); // The points in the actual path 
    public float pathPointSize; // The gizmo size of the path points
    public bool showPath; // Permanently show the path using gizmos
    public Vector3 pathOffset; // The path offset;

    // Gizmo settings
    public Color lineColor;
    public Color pointColor;
    public GameObject pathBlockerPrefab;
    public GameObject pathBlockerParent;

    private void OnDrawGizmos()
    {
        if (showPath)
        {
            for (int i = 0; i < pathPoints.Count; i++)
            {
                //pathfindScript.pathPoints[i] = Handles.PositionHandle(pathfindScript.transform.position, Quaternion.identity);
                Gizmos.color = pointColor;
                Gizmos.DrawSphere(pathPoints[i], pathPointSize); // Set points at all gizmos
                if (i + 1 < pathPoints.Count)
                {

                    Gizmos.color = lineColor;
                    Gizmos.DrawLine(pathPoints[i], pathPoints[i + 1]); // Draw a line between all gizmos
                }
            }

        }
    }

    public void GeneratePathBlockers()
    {
        for (int i = 0; i < pathPoints.Count - 1; i++)
        {
            GameObject newPathBlocker = Instantiate(pathBlockerPrefab, pathBlockerParent.transform);
            newPathBlocker.transform.position = Vector3.Lerp(pathPoints[i], pathPoints[i + 1], 0.5f);
            newPathBlocker.transform.position += new Vector3(0, 0.5f, 0);
            newPathBlocker.transform.localScale = new Vector3(1, 1, 1 * Vector3.Distance(pathPoints[i], pathPoints[i + 1]) + 1f);
            newPathBlocker.transform.LookAt(pathPoints[i + 1] + new Vector3(0, .5f, 0));
        }
    }
}
