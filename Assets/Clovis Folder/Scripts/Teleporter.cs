using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{    
    public Transform destination;
    [SerializeField] GameObject teleportObject;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            teleportObject = other.gameObject;
            StartCoroutine("Teleport");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            teleportObject = null;
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        teleportObject.SetActive(false);
        yield return null;
        teleportObject.transform.position = destination.position;
        yield return null;
        teleportObject.SetActive(true);
        yield return null;
        teleportObject = null;
    }
}