using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            Col.gameObject.GetComponent<PlayerCutscene>().buttoncollision = true;
            Debug.Log("COLLISION");

        }
    }

    void OnTriggerExit(Collider Col)
    {
        if(Col.gameObject.tag == "Player")
        {
            if (!Col.gameObject.GetComponent<PlayerCutscene>().animationIsPlaying)
            {
                Col.gameObject.GetComponent<PlayerCutscene>().buttoncollision = false;
                Debug.Log("CollisionEnd");
            }
        }
    }
}
