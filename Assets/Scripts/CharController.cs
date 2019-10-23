using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 6f;  
    public float maxSpeed = 100f;
    public float jumpSpeed = 8f;
    public float gravity = 50f;
    public float rotateSpeed = 6f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    private float lastSpaceKeyDownTime;

    private float defaultJumpSpeed;
    private float defaultSpeed;
    private bool running;
    private float timer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        defaultJumpSpeed = jumpSpeed;
        defaultSpeed = speed;
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.W) || running)
            {
                if (!Input.GetKey(KeyCode.W))
                {
                    ResetSpeed();
                }
                running = true;
                timer += 0.1f;
                
                if (timer > 1 && speed < maxSpeed)
                {
                    speed *= 1.1f;
                }
            }

            moveDirection = Input.GetAxis("Vertical") * speed * transform.forward;
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

    private void ResetSpeed()
    {
        timer = 0f;
        speed = defaultSpeed;
    }
}
