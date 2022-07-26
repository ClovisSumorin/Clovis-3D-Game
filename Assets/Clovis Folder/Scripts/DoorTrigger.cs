using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    bool isOpened = false;

    public AudioSource Door;

    void OnTriggerEnter(Collider col)
    {
        if (!isOpened)
        {
            isOpened = true;
            door.transform.position += new Vector3(-10, 0, 0);

            Door.Play();
        }
    }
}
