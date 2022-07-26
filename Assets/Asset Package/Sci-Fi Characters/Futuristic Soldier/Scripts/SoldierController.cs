using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour {

    public enum PlayerNumber { player1, player2 }
    public PlayerNumber player;
    string playerString;

    CharacterController controller;
    Animator anim;
    public float moveSpeed = 5f;
    public float lookRotationSensitivity = 90f;

    //Vector3 lastMousePosition; // Saves the mouse position on the last frame.

    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        //lastMousePosition = Input.mousePosition;

        // Determines the player string to add to controls.
        if(player == PlayerNumber.player1) playerString = " (Player 1)";
        else playerString = " (Player 2)";
    }

    // Update is called once per frame
    void Update() {
        LookUpdate();
        MovementUpdate();

        // Play the melee button.
        if(Input.GetKeyDown(KeyCode.Joystick1Button0)) Debug.Log("Square");
        if(Input.GetButtonDown("Fire3" + playerString)) anim.SetTrigger("Melee");
        else if(Input.GetButtonDown("Fire1" + playerString)) anim.SetTrigger("Firing");
    }

    void MovementUpdate() {
        // Listens to WASD, and arrow keys.
        float h = Input.GetAxis("Horizontal" + playerString);
        float v = Input.GetAxis("Vertical" + playerString);

        // Converts the movement vector to be a vector in local space of the soldier.
        //Vector3 displacement = transform.TransformVector( new Vector3(h, 0, v) );
        Vector3 displacement = transform.forward * v + transform.right * h;

        // Update animation.
        anim.SetFloat("MoveVertical", v);
        anim.SetFloat("MoveHorizontal", h);
        anim.SetBool("IsMoving", displacement.sqrMagnitude > 0);

        // Move the character around.
        controller.Move(displacement * moveSpeed * Time.deltaTime);
    }

    // Receive input for rotation and updates player rotation.
    void LookUpdate() {
        float mouseX = Input.GetAxis("Mouse X" + playerString);
        
        //Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
        transform.Rotate(0, mouseX * Time.deltaTime * lookRotationSensitivity, 0);
        //lastMousePosition = Input.mousePosition;
    }
}
