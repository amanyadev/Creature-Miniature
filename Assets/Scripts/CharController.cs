using UnityEngine;

public class CharController : MonoBehaviour
{
    public float movementSpeed = 6f;  
    public float maxMovementSpeed = 100f;
    public float jumpSpeed = 8f;
    public float gravity = 50f;
    public float rotateSpeed = 6f;
    public float accelerationSpeed = 75f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    private float lastSpaceKeyDownTime;
    private float defaultJumpSpeed;
    private float defaultMovementSpeed;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        defaultJumpSpeed = jumpSpeed;
        defaultMovementSpeed = movementSpeed;
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W) &&
                movementSpeed < maxMovementSpeed)
            {
                movementSpeed += accelerationSpeed * Time.deltaTime;
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                movementSpeed = defaultMovementSpeed;
            }

            moveDirection = Input.GetAxis("Vertical") * movementSpeed * transform.forward;
            transform.Rotate(0f, Input.GetAxis("Horizontal") * rotateSpeed, 0f);

            // Power jump if button is held
            if (Input.GetKey(KeyCode.Space))
            {
                StartPreparingJump();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                Jump();
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        jumpSpeed = defaultJumpSpeed;
    }

    private void StartPreparingJump()
    {
        lastSpaceKeyDownTime = Time.time;
    }

    private void Jump()
    {
        lastSpaceKeyDownTime = Time.time - lastSpaceKeyDownTime;
        if (lastSpaceKeyDownTime > 1f && lastSpaceKeyDownTime < 3f)
        {
            jumpSpeed = lastSpaceKeyDownTime * jumpSpeed;
        }
        else if (lastSpaceKeyDownTime > 1.5f)
        {
            jumpSpeed *= 2f;
        }
        moveDirection.y = jumpSpeed;
    }
}
