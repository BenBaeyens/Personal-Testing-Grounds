using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPull : MonoBehaviour
{

    public GameObject player; // The player
    CharacterController cc; // The player's RigidBody component.

    public float speed = 60f; // The speed at which the gameobject is dragged forward.

    
    void Start()
    {
        if(!player.TryGetComponent<CharacterController>(out cc))
            Debug.LogWarning("ControllerPull: Player RigidBody not found.");
    }

    void Update()
    {
        if(cc != null)
            cc.SimpleMove(player.transform.forward * speed * Time.deltaTime);
    }
}
