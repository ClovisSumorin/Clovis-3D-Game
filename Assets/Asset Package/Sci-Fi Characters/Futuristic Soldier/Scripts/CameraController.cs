using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public float smoothing;

    public bool snapToTargetCoordinates = true;
    public bool allowVerticalLook = true;
    [Range(0f,90f)]public float verticalLookRange = 45;

    float verticalLook = 0; // Our rotation for looking vertically.

    public string player = "P1";

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        if (allowVerticalLook)
        {
            verticalLook += Input.GetAxis("Mouse Y" + player);
            verticalLook = Mathf.Clamp(
                verticalLook, -verticalLookRange, verticalLookRange);
        }

        // Orient the offset to the target coordinates.
        Vector3 o = offset;
        if (snapToTargetCoordinates)
        {
            o = Quaternion.Euler(
                verticalLook, target.rotation.eulerAngles.y, 0) * offset;

            // rotate the camera also.
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.Euler(verticalLook, target.rotation.eulerAngles.y, 0),
                Time.deltaTime * smoothing);
        }

        //smoothly pans the camera to the desired location.
        transform.position = Vector3.Lerp(
            transform.position,
            target.position + o,
            Time.deltaTime * smoothing);

        //transform.LookAt(target);
    }
}
