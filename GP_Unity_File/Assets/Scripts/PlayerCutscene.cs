using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCutscene : MonoBehaviour
{
    public Animator ButtonAnimator;
    public Animator DoorAnimator;
    public Animator CutSceneCam;
    public Animator playerAnimator;

    public GameObject CutSceneCamera;
    public GameObject playerCamera;

    public bool buttoncollision = false;
    public bool ButtonAnimation = false;
    public bool animationIsPlaying = false;
    public float CollisionTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (buttoncollision && ButtonAnimation)
        {
            animationIsPlaying = true;
            CutSceneCam.SetTrigger("CAM");
            playerCamera.SetActive(false);

            CutSceneCamera.SetActive(true);




            ButtonAnimator.SetTrigger("Pushed");

            CollisionTimer += Time.deltaTime;

            if (CollisionTimer >= 1.5)
            {
                DoorAnimator.SetTrigger("DoorOpen");
            }
            if (CollisionTimer >= 4.5)
            {
                CutSceneCamera.SetActive(false);
                playerCamera.SetActive(true);
                animationIsPlaying = false;
            }
        }
    }

    public void ButtonInteraction()
    {
        Debug.Log("ButtonInteract");
        playerAnimator.SetTrigger("Interact");
        ButtonAnimation = true;
    }
}