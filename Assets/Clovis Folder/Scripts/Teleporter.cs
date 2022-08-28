using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portal;   //Stores a reference to the portal to teleport to
    public CharacterController ThirdPersonPlayer;   //Stores a reference to the carController script

    private void OnTriggerEnter(Collider other)
    {
        //Checks if a car is passing thru the portal
        if (other.tag == "ThirdPersonPlayer")
        {
            ThirdPersonPlayer.transform.position = portal.transform.position;   //Sets the car's position to that of the portal
            ThirdPersonPlayer.transform.localRotation = portal.transform.localRotation;   //Sets the car's rotation to that of the portal
        }
    }
}