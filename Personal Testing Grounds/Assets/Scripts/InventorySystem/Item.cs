using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public bool stacks; // Whether or not the item stacks
    public int maxStack; // The maximum stack count of the item (in development)
    public int currentStack = 1; // The current stack count, default is one (1)

    public float weight; // The weight of the item

    public Sprite icon; // How the object looks in the UI
}
