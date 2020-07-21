using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindFollower : MonoBehaviour
{
    public PathfindScript path;

    bool hasStarted = false;
    public float speed;
    public float pointReachedDelay; // How long the object waits after reaching a point
    public float checkDistance;

    int currentPathPoint;
    float lerp;
    float distanceBetweenPoints;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            currentPathPoint = 0;
        }

        if (hasStarted && currentPathPoint + 1 < path.pathPoints.Count)
        {
            //Calculate the distance between the points so the speed is uniform
            distanceBetweenPoints = Vector3.Distance(path.pathPoints[currentPathPoint], path.pathPoints[currentPathPoint + 1]);

            lerp += Time.deltaTime / speed / distanceBetweenPoints;

            // Set transform values
            transform.position = Vector3.Lerp(path.pathPoints[currentPathPoint], path.pathPoints[currentPathPoint + 1], lerp);
            transform.LookAt(path.pathPoints[currentPathPoint + 1]);

            // If destination is reached, go to next point
            if (Vector3.Distance(transform.position, path.pathPoints[currentPathPoint + 1]) <= 0 + checkDistance)
            {
                currentPathPoint++;
                lerp = 0;
                StartCoroutine("Delay");
            }
        }
        else
        {
            hasStarted = false;
            Debug.Log("Reached the end of the path");
        }
    }

    IEnumerator Delay()
    {
        float tempSpeedValue = speed;
        speed = int.MaxValue;
        yield return new WaitForSeconds(pointReachedDelay);
        speed = tempSpeedValue;
    }
}
