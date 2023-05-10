using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSlime : MonoBehaviour
{
    public int slime_health;
    private int slime_hop_speed;
    private bool slime_single_death;
    private bool slime_start_hop;
    private Vector3 slime_hop_dir;

    private GameObject player_object;
    private SlimeBox slimebox_script;
    private Rigidbody slime_rb;

    void Awake()
    {
        slime_start_hop = false;
        player_object = GameObject.Find("Player");
        slimebox_script = GameObject.Find("SlimeBox").GetComponent<SlimeBox>();
        slime_rb = GetComponent<Rigidbody>();

        slime_hop_speed = 300;
        slime_single_death = false;

        slime_health = 1;
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    void Update()
    {
        if (slimebox_script.b_player_in_box)
        {
            if (!slime_start_hop)
            {
                slime_start_hop = true;
                StartCoroutine(SlimeHopDelay());
                slime_hop_dir = (player_object.transform.position - this.transform.position).normalized;
                slime_rb.AddForce(new Vector3(slime_hop_dir.x * slime_hop_speed, slime_hop_speed, slime_hop_dir.z * slime_hop_speed));
            }
        }

        if (slime_health <= 0 && !slime_single_death)
        {
            slime_single_death = true;

            Destroy(this.gameObject);
        }
    }

    private IEnumerator SlimeHopDelay()
    {
        yield return new WaitForSeconds(2);
        slime_start_hop = false;
    }
}
