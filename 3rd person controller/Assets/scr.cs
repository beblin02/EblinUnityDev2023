using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class scr : MonoBehaviour
{
    //input variables
    private Vector2 input_Vector;

    public Rigidbody rigidbody;
    public Transform player;
    public Transform player_model;
    public Transform orientation;
    public float move_force;
    public float rotation_speed;
    private Vector3 direction;

    //cam
    public Transform Camera;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetMoveInput(InputAction.CallbackContext context)
    {
        input_Vector = context.ReadValue<Vector2>();
    }

    public void GetJumpInput(InputAction.CallbackContext context)
    {

    }



    public void RotateLayermodel()
    {
        Vector3 view_direction = player.position - new Vector3(Camera.position.z, Camera.position.y, Camera.position.x);
    
        orientation.forward = view_direction;

        direction = orientation.right * input_Vector * orientation.forward * input_Vector.y;
        direction = direction.normalized;

        if(input_Vector = Vector2.zero)
        {
            player.model.forward = Vector2.Slurp(player)
        }
    }

}
