using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryScript : MonoBehaviour {
 

    public GameObject testObj;
    public GameObject testObj2;
    public GameObject testObj3;

    public int rows = 5; // The amount of rows the inventory has.
    public int collums = 4; // The amount of collums the inventory has.

    public List<GameObject> slots; // The list for all the objects in the inventory
    float weight = 0.0f; // Optional weight functionality

    GameObject player; // The player gameobject

    private void Start() {
        player = GameObject.FindWithTag("Player");
        slots = new List<GameObject>(rows * collums); // Creates a new list based on the specifications set in the inspector.
        for (int i = 0; i < rows * collums; i++)
        {
            slots.Add(null);
        }
    }

    private void NewItem(GameObject obj){
        Item item = obj.GetComponent<Item>();

        for (int i = 0; i < slots.Count; i++)
        {
            if(item.stacks && slots[i]){
                if(slots[i].name == obj.name){
                    slots[i].GetComponent<Item>().currentStack += item.currentStack;
                    Destroy(obj);
                    break;
                }
            }
            if(!slots[i]){
                slots[i] = obj;
                weight += item.weight;
                obj.transform.parent = transform;
                obj.SetActive(false);
                break;
            }
            else if(i + 1 >= slots.Count){
                Debug.Log("InventoryScript: Your inventory is full.");
                break;
            }
        }
    }

    void DropItem(GameObject obj){
        for (int i = 0; i < slots.Count; i++)
        {
            if(slots[i] == obj){
                Item item = slots[i].GetComponent<Item>();
                Sprite icon = item.icon;
                Transform transf = player.transform;
                Vector3 pos = transf.position;

                slots[i].transform.parent = null;
                slots[i].transform.position = pos + transf.TransformDirection(new Vector3(0, 0.5f, 0.5f));
                slots[i].SetActive(true);

                weight -= item.weight;

                slots[i] = null;
            }
        }
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            NewItem(testObj);
        }
        if(Input.GetKeyDown(KeyCode.B)){
            NewItem(testObj2);
        }
        if(Input.GetKeyDown(KeyCode.C)){
            NewItem(testObj3);
        }

        
        if(Input.GetKeyDown(KeyCode.Keypad1)){
            DropItem(slots[0]);
        }
        if(Input.GetKeyDown(KeyCode.Keypad2)){
            DropItem(slots[1]);
        }
        
        if(Input.GetKeyDown(KeyCode.Keypad3)){
            DropItem(slots[2]);
        }
    }

}