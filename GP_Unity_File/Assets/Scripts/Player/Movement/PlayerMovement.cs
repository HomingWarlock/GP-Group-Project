using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Inputs controls;
    public GameObject player;
    public Animator playerAnimator;
    public GameObject groundCheck;

    public float movementSmoothingTime = 0.1f;
    private float turnSmoothing;

    private float movementX;
    private float movementY;
    private float movementZ;
    public float groundCheckDistance = 0.4f;
    private Vector3 movementDirection;

    public float playerSpeed = 5.0f;
    private float rotationAngle;
    private float playerRotationAngle;
    public Camera playerCam;

    public bool isJumping = false;
    public bool isGrounded = true;
    public bool isDoubleJumpUnused = true;
    public bool isRunning = false;
    public Vector3 currentVelocity;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controls = new Inputs();
        playerAnimator = player.GetComponent<Animator>();
    }

    public void OnEnable()
    {
        controls.Player.Enable();
    }

    public void OnDisable()
    {
        controls.Player.Disable();
    }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementZ = movementVector.y;
        /*
        if ((movementX == 0.0f) && (movementZ == 0.0f))
        {
            playerAnimator.SetBool("Moving", false);
        }
        else
        {
            playerAnimator.SetBool("Moving", true);
        }
        */
    }

    public void OnRun(InputValue Run)
    {
        Debug.Log(Run);
        if (isRunning)
        {
            isRunning = !isRunning;
            playerAnimator.SetBool("Running", false);
        }
        else
        {
            isRunning = !isRunning;
            playerAnimator.SetBool("Running", true);
        }
    }

    private void OnLook(InputValue cameraRotation)
    {
        Vector2 CameraRotationVector = cameraRotation.Get<Vector2>();
        playerCam.GetComponent<CameraMovement>().OnLook(CameraRotationVector);
    }

    private void OnJump(InputValue Jump)
    {
        if (!player.GetComponent<PlayerCombat>().combat_attack_delay)
        {
            if (!isJumping && isGrounded)
            {
                player.GetComponent<Rigidbody>().AddForce(0.0f, 400.0f, 0.0f);
                playerAnimator.SetBool("Jumping", true);
                isJumping = true;
                isGrounded = false;
            }
            else if (isDoubleJumpUnused)
            {
                player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                player.GetComponent<Rigidbody>().AddForce(0.0f, 400.0f, 0.0f);
                playerAnimator.SetBool("DoubleJump", true);
                isJumping = true;
                isDoubleJumpUnused = false;
            }
        }
    }
    
    private void OnAction(InputValue Action)
    {
        Debug.Log("Action Test");
        //Zenna's Action Code could go here
    }

    private void OnCameraLock(InputValue Lock)
    {
        Debug.Log("Camera Lock Test");
        //Camera Locking code can go here
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, movementY, movementZ);
        rotationAngle = Mathf.Atan2(movementX, movementZ) * Mathf.Rad2Deg + playerCam.transform.eulerAngles.y;
        playerRotationAngle = Mathf.SmoothDampAngle(player.transform.eulerAngles.y, rotationAngle, ref turnSmoothing, movementSmoothingTime);
        if (!player.GetComponent<PlayerCombat>().combat_attack_delay)
        {
            if (movementX >= 0.2f || movementX <= -0.2f || movementZ >= 0.2f || movementZ <= -0.2f)
            {
                movementDirection = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;
                playerAnimator.SetBool("Moving", true);
                player.transform.rotation = Quaternion.Euler(0.0f, playerRotationAngle, 0.0f);
            }
            else
            {
                movementDirection = new Vector3(0.0f, 0.0f, 0.0f);
                playerAnimator.SetBool("Moving", false);
            }

            player.transform.Translate(movementDirection * playerSpeed * Time.deltaTime, Space.World);
        }
 
    }

    private void Update()
    {
        if (buttoncollision == true && ButtonAnimation == true )
        {
            CutSceneCam.SetTrigger("CAM");
            playerCamera.SetActive(false);

            CutSceneCamera.SetActive(true);


            

            ButtonAnimator.SetTrigger("Pushed");
           
            CollisionTimer += Time.deltaTime;

            if(CollisionTimer >=1.5)
            {
                DoorAnimator.SetTrigger("DoorOpen");
                Debug.Log("Open");
            }
            if (CollisionTimer >= 4.5)
            {
                CutSceneCamera.SetActive(false);
                playerCamera.SetActive(true);
            }
        }


    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Button")
        {
            buttoncollision = true;
            Debug.Log("COLLISION");

        }




    }

    
}
