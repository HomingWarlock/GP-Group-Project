using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumSlime : MonoBehaviour
{
    public int slime_health;
    private int slime_hop_speed;
    private bool slime_single_death;
    private bool slime_start_hop;
    private Vector3 slime_hop_dir;

    private Transform slime_spawn1;
    private Transform slime_spawn2;

    private GameObject player_object;
    [SerializeField] private GameObject small_slime_object;
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

        slime_health = 2;
        transform.localScale = new Vector3(1, 1, 1);
        slime_spawn1 = transform.Find("SpawnPos1");
        slime_spawn2 = transform.Find("SpawnPos2");
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

            GameObject smaller_slime1 = Instantiate(small_slime_object, new Vector3(slime_spawn1.position.x, slime_spawn1.position.y, slime_spawn1.position.z), Quaternion.identity) as GameObject;
            SmallSlime smaller_script1 = smaller_slime1.GetComponent<SmallSlime>() as SmallSlime;
            smaller_slime1.transform.name = "Small Slime";
            smaller_slime1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            smaller_script1.slime_health = 1;

            GameObject smaller_slime2 = Instantiate(small_slime_object, new Vector3(slime_spawn2.position.x, slime_spawn2.position.y, slime_spawn2.position.z), Quaternion.identity) as GameObject;
            SmallSlime smaller_script2 = smaller_slime2.GetComponent<SmallSlime>() as SmallSlime;
            smaller_slime2.transform.name = "Small Slime";
            smaller_slime2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            smaller_script2.slime_health = 1;

            Destroy(this.gameObject);
        }
    }

    private IEnumerator SlimeHopDelay()
    {
        yield return new WaitForSeconds(2);
        slime_start_hop = false;
    }
}
