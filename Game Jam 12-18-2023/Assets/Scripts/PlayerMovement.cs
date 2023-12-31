using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input")]
    public KeyCode sprint;
    public KeyCode jump;

    [Header("References")]
    [SerializeField] private Transform cam;

    [Header("Movement")]
    public float speed;
    public float turnSmoothTime;
    public float spritingMultipler;

    [Header("Jumping")]
    public float gravity;
    public float jumpSpeed = 15;

    CharacterController controller;

    float turnSmoothVelocity;
    Vector3 moveVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Player movement
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // direction player is moving
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // move player
            controller.Move(speed * Time.deltaTime * moveDirection.normalized);
        }

        if (controller.isGrounded)
        {
            // Player jumps
            if (Input.GetKey(jump))
            {
                moveVelocity.y = jumpSpeed;

                Debug.Log("Pressed");
            }
        }

        // Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        controller.Move(moveVelocity * Time.deltaTime);
    }
}