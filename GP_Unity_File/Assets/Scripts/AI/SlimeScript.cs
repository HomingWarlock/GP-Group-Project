using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    [SerializeField] private int slime_health;
    private float slime_size;
    private bool slime_dmg_delay;
    [SerializeField] private GameObject slime_object;
    [SerializeField] private GameObject slime_mini_object;
    private Transform slime_spawn1;
    private Transform slime_spawn2;

    void Awake()
    {
        if (this.transform.name == "Big Slime")
        {
            slime_health = 2;
            slime_size = 2.5f;
        }

        if (this.transform.name == "Medium Slime")
        {
            slime_health = 1;
            slime_size = 1.5f;
        }

        if (this.transform.name == "Small Slime")
        {
            slime_health = 1;
            slime_size = 0.5f;
        }

        if (this.transform.name != "Small Slime")
        {
            slime_spawn1 = transform.Find("SpawnPos1");
            slime_spawn2 = transform.Find("SpawnPos2");
        }

        transform.localScale = new Vector3(slime_size, slime_size, slime_size);
        slime_dmg_delay = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !slime_dmg_delay)
        {
            slime_dmg_delay = true;
            StartCoroutine(Slime_DMG_Delay());
            slime_health -= 1;

            if (slime_health <= 0)
            {
                if (this.transform.name == "Big Slime")
                {
                    GameObject smaller_slime1 = Instantiate(slime_object, slime_spawn1.position, Quaternion.identity) as GameObject;
                    GameObject smaller_slime2 = Instantiate(slime_object, slime_spawn2.position, Quaternion.identity) as GameObject;
                    Destroy(this.gameObject);
                }
            }
        }
    }

    IEnumerator Slime_DMG_Delay()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            slime_dmg_delay = false;
        }
    }
}
