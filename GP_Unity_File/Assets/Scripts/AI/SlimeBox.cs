using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBox : MonoBehaviour
{
    public bool b_player_in_box;

    void Start()
    {
        b_player_in_box = false;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.transform.name == "Player")
        {
            b_player_in_box = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.transform.name == "Player")
        {
            b_player_in_box = false;
        }
    }
}
