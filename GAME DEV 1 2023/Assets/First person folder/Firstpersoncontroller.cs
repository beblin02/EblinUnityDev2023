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
    public float cam_x_rotation = 0f;
   



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouse_movement = context.ReadValue<Vector2>();
       // Debug.Log("Muse movement: " + mouse_movement.ToString());
    }



}
