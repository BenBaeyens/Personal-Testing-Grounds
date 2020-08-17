using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystemScript : MonoBehaviour
{

    public static BuildSystemScript Instance { get; private set; }

    // Addressable objects
    public GameObject foundation;
    public GameObject[] floors;
    public GameObject[] wallVariants;

    public enum CurrentBuildType
    {
        Foundation,
        Wall,
        Floor,
        Roof
    }


    // Variables
    public bool isPlacing;
    public GameObject currentlyPlacingObject;
    Vector3 mousePosition;
    CurrentBuildType currentBuildType;
    int currentVariant = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isPlacing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (currentBuildType == CurrentBuildType.Foundation)
                {
                    currentlyPlacingObject.transform.position = new Vector3(Mathf.Round(hit.point.x), hit.point.y - .5f, Mathf.Round(hit.point.z));
                }
                else
                {
                    currentlyPlacingObject.transform.position = new Vector3(Mathf.Round(hit.point.x), hit.point.y - .05f, Mathf.Round(hit.point.z));
                }
            }
        }

        if (isPlacing && Input.GetMouseButtonDown(0))
        {
            // Get the actual visual object and remove its raycast block
            currentlyPlacingObject.transform.parent.GetChild(0).gameObject.layer = 0;
            isPlacing = false;
        }

        if (isPlacing && currentBuildType == CurrentBuildType.Wall && Input.GetKeyDown(KeyCode.R))
        {
            // Rotate wall if placing wall

        }
    }

    public void PurchaseNewBuild(int buildType)
    {
        switch ((CurrentBuildType)buildType)
        {
            case CurrentBuildType.Foundation:
                currentlyPlacingObject = Instantiate(foundation).GetComponentInChildren<PositionSphereLocator>().gameObject;
                break;
            case CurrentBuildType.Wall:
                currentlyPlacingObject = Instantiate(wallVariants[0]).GetComponentInChildren<PositionSphereLocator>().gameObject;
                break;
            case CurrentBuildType.Floor:
                currentlyPlacingObject = Instantiate(floors[0]).GetComponentInChildren<PositionSphereLocator>().gameObject;
                break;
            case CurrentBuildType.Roof:
                currentBuildType = CurrentBuildType.Roof;
                break;
        }

        currentBuildType = (CurrentBuildType)buildType;

        isPlacing = true;
    }


}
