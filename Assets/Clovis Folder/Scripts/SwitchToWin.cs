using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToWin : MonoBehaviour
{
    public string sceneToLoad;

    public MouseLook Mouse;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
