using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHitbox : MonoBehaviour
{
    public PlayerCombat combat_script;

    void OnTriggerStay(Collider col)
    {
        if (combat_script.combat_attack_delay)
        {
            if (col.transform.name == "Big Slime" || col.transform.name == "Medium Slime" || col.transform.name == "Small Slime")
            {
                if (!combat_script.combat_single_attack)
                {
                    col.gameObject.GetComponent<SlimeScript>().slime_health -= 1;
                    combat_script.combat_single_attack = true;
                }
            }
        }
    }
}
