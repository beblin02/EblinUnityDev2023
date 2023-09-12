using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Firstpersoncontroller : MonoBehaviour
{
    //Player Variables
    public float speed;
    public float gravity = -9.0f;
    public float jump_force = 10f;
    private CharacterController characterController;
    private Vector2 move_imput;
    private Vector3 player_velocity;
    private bool grounded;
    private Vector2 mouse_movement;

    //CAmera 
    public Camera camera;
    public float sensitivity = 30;
    private float cam_x_rotation = 0f; 
   



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        grounded = characterController.isGrounded;
        MovePlayer();
        Look();
       
    }


    //Capture Imput 
    public void OnMove(InputAction.CallbackContext context)
    {
        move_imput = context.ReadValue<Vector2>();
       // Debug.Log("Move Input: " + move_imput.ToString());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("Pressed the jump key");
        Jump();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouse_movement = context.ReadValue<Vector2>();
       // Debug.Log("Muse movement: " + mouse_movement.ToString());
    }

    public void MovePlayer()
    {
        //Move player
        Vector3 move_vec = transform.right * move_imput.x +transform.forward * move_imput.y;
        characterController.Move(move_vec * speed * Time.deltaTime);

        //Player Gravity
        player_velocity.y += gravity * Time.deltaTime;
        if (grounded && player_velocity.y < 0)
        {
            player_velocity.y = -2;
        }
        characterController.Move(player_velocity * Time.deltaTime);
    }

        //Player look
    public void Look()
    {
        float x_amount = mouse_movement.y * sensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up *mouse_movement.x *sensitivity *Time.deltaTime);

        cam_x_rotation -= x_amount;
        cam_x_rotation = Mathf.Clamp(cam_x_rotation, -90, 90);

        camera.transform.localRotation = Quaternion.Euler(cam_x_rotation, 0, 0);

    }

    //jumpo
    public void Jump()
    {
        if(grounded)
        {
            player_velocity.y = jump_force;

        }

    }


}
