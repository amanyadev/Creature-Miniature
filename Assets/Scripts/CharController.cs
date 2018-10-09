using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 6.0f;  //current speed
    public float maxSpeed = 100f;
    public float jumpSpeed = 8.0f;
    public float gravity = 50f;
    public float rotateSpeed = 6;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    //Timer t;

    bool keyActive = false;
    float heldDownTimer;

    float defaultJumpSpeed;
    float defaultSpeed;
    bool running = false;
    float timer = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //t = GetComponent<Timer> ();
        defaultJumpSpeed = jumpSpeed;
        defaultSpeed = speed;
        timer = 0;
    }


    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            if (Input.GetKeyDown("w") == true || running == true)
            {
                if (Input.GetKey("w") != true)
                {
                    timer = 0;
                    running = false;
                    speed = defaultSpeed;
                }
                if (running == false)
                {
                    running = true;
                }
                timer += 0.1f;
                //Debug.Log(timer);
                if (timer > 1 && speed < maxSpeed)
                {
                    speed = speed * 1.1f;
                }
            }
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
            bool jumping = Input.GetKey("space") && Input.GetKey("w");
            // Power jump if button is held
            if ((Input.GetKeyDown("space") || jumping) && keyActive == false)
            {
                heldDownTimer = Time.time;
                keyActive = true;
            }
            if (Input.GetKeyUp("space") && keyActive == true)
            {
                heldDownTimer = Time.time - heldDownTimer;
                keyActive = false;
                if (heldDownTimer > 1 && heldDownTimer < 3)
                {
                    jumpSpeed = heldDownTimer * jumpSpeed;
                }
                else if (heldDownTimer > 1.5f)
                {
                    jumpSpeed = jumpSpeed * 2;
                }
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        jumpSpeed = defaultJumpSpeed;

        #region Better Jump

        #endregion
    }
}
//	float keypressedDuration(string key){
//		float helddown=0;
//		if(Input.GetKeyDown(key)){
//			helddown = Time.time;
//		}
//		if(Input.GetKeyUp(key)){
//			helddown = Time.time - helddown;
//		}
//		return helddown;
//	}