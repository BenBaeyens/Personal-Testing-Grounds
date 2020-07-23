// Written by Ben Baeyens - https://www.benbaeyens.com/

// <summary>
// This script automatically snaps any component it's attached to to their corresponding values.
// </summary>

using UnityEngine;

[ExecuteInEditMode]
public class TowerScript : MonoBehaviour
{

    public bool _enabled;
    public bool _selected;

    public float snapValueX;
    public float snapValueY;
    public float snapValueZ;

    public float followSpeed; // The speed at which the object follows the snap object

    public GameObject towerObject;

    private void Start()
    {
        towerObject = transform.parent.GetChild(1).gameObject;
    }


    void Update()
    {
        if (_enabled && _selected)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, 1);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-1, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.position += new Vector3(0, -0.5f, 0);
                _selected = false;
            }



            if (snapValueX != 0)
                transform.position = new Vector3(Mathf.Round(transform.position.x * (1 / snapValueX)) / (1 / snapValueX), transform.position.y, transform.position.z);

            if (snapValueY != 0)
                transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y * (1 / snapValueY)) / (1 / snapValueY), transform.position.z);

            if (snapValueZ != 0)
                transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z * (1 / snapValueZ)) / (1 / snapValueZ));
        }
        towerObject.transform.position = Vector3.Lerp(towerObject.transform.position, transform.position, Time.deltaTime / followSpeed);



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PathBlocker"))
        {
            Debug.Log("NOPE");
        }
    }
}