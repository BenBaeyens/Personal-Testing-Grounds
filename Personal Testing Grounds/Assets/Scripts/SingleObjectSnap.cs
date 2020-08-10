// Written by Ben Baeyens - https://www.benbaeyens.com/

// <summary>
// This script automatically snaps any component it's attached to to their corresponding values.
// </summary>

using UnityEngine;

[AddComponentMenu("Ben's Script Library/Level Building/Single Object Snap")]
public class SingleObjectSnap : MonoBehaviour
{

    public bool _enabled;

    public float snapValueX;
    public float snapValueY;
    public float snapValueZ;
    public float smoothTime;

    Transform positionSphere;


    private void Start()
    {
        positionSphere = transform.parent.GetChild(1);
    }

    void Update()
    {
        if (Application.isPlaying && _enabled)
        {
            transform.position = Vector3.Lerp(transform.position, positionSphere.position, smoothTime);
            //     if (snapValueX != 0)
            //         transform.position = Vector3.Lerp(positionSphere.position, new Vector3(Mathf.Round(positionSphere.position.x * (1 / snapValueX)) / (1 / snapValueX), transform.position.y, transform.position.z), smoothTime * Time.deltaTime);

            //     if (snapValueY != 0)
            //         transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Mathf.Round(positionSphere.position.y * (1 / snapValueY)) / (1 / snapValueY), transform.position.z), smoothTime * Time.deltaTime);

            //     if (snapValueZ != 0)
            //         transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, Mathf.Round(positionSphere.position.z * (1 / snapValueZ)) / (1 / snapValueZ)), smoothTime * Time.deltaTime);
        }
    }
}