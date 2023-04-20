using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public bool combat_attack_delay;
    public bool combat_single_attack;

    void Start()
    {
        combat_attack_delay = false;
        combat_single_attack = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !combat_attack_delay)
        {
            combat_attack_delay = true;
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
