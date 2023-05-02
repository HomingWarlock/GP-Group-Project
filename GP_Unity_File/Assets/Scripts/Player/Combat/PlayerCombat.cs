using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public bool combat_attack_delay;
    public bool combat_single_attack;
    Inputs controls;
    public Animator playerAnimator;

    void Awake()
    {
        combat_attack_delay = false;
        combat_single_attack = false;
        controls = GetComponent<PlayerMovement>().controls;
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Space) && !combat_attack_delay)
        {
            combat_attack_delay = true;
            StartCoroutine(Combat_Attack_Delay());
        }
        */
    }

    private void OnAttack(InputValue attack)
    {
        if (!combat_attack_delay && GetComponent<PlayerMovement>().isGrounded)
        {
            combat_attack_delay = true;
            playerAnimator.SetBool("Attacking", true);
            StartCoroutine(Combat_Attack_Delay());
        }
    }

    IEnumerator Combat_Attack_Delay()
    {
        yield return new WaitForSeconds(1);
        combat_attack_delay = false;
        combat_single_attack = false;
    }
}
