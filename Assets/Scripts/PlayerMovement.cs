using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSmoothing = 0.1f;
    [SerializeField] private Transform cam;
    [SerializeField] private float gravity = 10;
    [SerializeField] private float jumpAmount = 3f;
    [SerializeField] private Animator myAnim;



    private Vector3 movement;
    private CharacterController myController;
    private float rotateVelocity;
    private float horizontalInput;
    private Vector3 velocity;

    public CinemachineVirtualCamera cinemachinecamera;



    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();

        horizontalInput = 1;

        //face Forward
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);
    }


    public void Startgame()
    {
        cinemachinecamera.Priority = 100;
        
        
    }



    void Update()
    {

      

        //control of player character using mouse movement and the scene view
        var planerMovementSpeed = new Vector3(myController.velocity.x, myController.velocity.z).magnitude;
        myAnim.SetFloat("speed", planerMovementSpeed);

        movement.y -= gravity * Time.deltaTime;

        Vector3 moveV = new Vector3(0f, movement.y, 0f);
        myController.Move(moveV * Time.deltaTime);

        if (movement.x == 0f && movement.z == 0f) return;

        float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,ref rotateVelocity, rotationSmoothing);


        //movement speed of the view along with the player rotation
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


        myController.Move(movDir * (speed * Time.deltaTime));

    
    }
    // input systems for the movement
    public void Move(InputAction.CallbackContext context)
    {
        var moveInput = context.ReadValue<Vector2>();
        movement = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (myController.isGrounded)
        {
            movement.y = jumpAmount;
            myAnim.SetTrigger("Jump");
        }
    }

 

}
