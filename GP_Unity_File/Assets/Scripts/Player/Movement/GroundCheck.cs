using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject player;
    public Animator playerAnimator;
    public LayerMask playerMask;
    public LayerMask barrelMask;


    // Start is called before the first frame update
    void Awake()
    {
        playerMask = ~playerMask;
        playerAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit groundHit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out groundHit, 1, playerMask))
        {
            if(groundHit.transform.gameObject.layer == LayerMask.NameToLayer("Barrel"))
            {
                Debug.Log("BarrelTest");
            }
            player.GetComponent<PlayerMovement>().isGrounded = true;
            player.GetComponent<PlayerMovement>().isJumping = false;
            player.GetComponent<PlayerMovement>().isDoubleJumpUnused = true;
            playerAnimator.SetBool("Grounded", true);
            playerAnimator.SetBool("Jumping", false);
        }
        else 
        {
            player.GetComponent<PlayerMovement>().isGrounded = false;
            playerAnimator.SetBool("Grounded", false);
        }
    }
}
