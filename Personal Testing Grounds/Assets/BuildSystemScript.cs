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


    // Variables
    public bool isPlacing;
    public GameObject currentlyPlacingObject;
    Vector3 mousePosition;

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
                currentlyPlacingObject.transform.position = hit.point;
            }
        }
    }


}
