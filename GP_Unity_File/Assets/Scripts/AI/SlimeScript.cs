using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public int slime_health;
    private int slime_hop_speed;
    private bool slime_single_death;
    private bool slime_start_hop;
    private Vector3 slime_hop_dir;

    private Transform slime_spawn1;
    private Transform slime_spawn2;

    private GameObject player_object;
    [SerializeField] private GameObject medium_slime_object;
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

        slime_health = 3;
        transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
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

            GameObject medium_slime1 = Instantiate(medium_slime_object, new Vector3(slime_spawn1.position.x, slime_spawn1.position.y, slime_spawn1.position.z), Quaternion.identity) as GameObject;
            MediumSlime medium_script1 = medium_slime1.GetComponent<MediumSlime>() as MediumSlime;
            medium_slime1.transform.name = "Medium Slime";
            medium_slime1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            medium_script1.slime_health = 2;
            
            GameObject medium_slime2 = Instantiate(medium_slime_object, new Vector3(slime_spawn2.position.x, slime_spawn2.position.y, slime_spawn2.position.z), Quaternion.identity) as GameObject;
            MediumSlime medium_script2 = medium_slime2.GetComponent<MediumSlime>() as MediumSlime;
            medium_slime2.transform.name = "Medium Slime";
            medium_slime2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            medium_script2.slime_health = 2;
            
            Destroy(this.gameObject);
        }
    }

    private IEnumerator SlimeHopDelay()
    {
        yield return new WaitForSeconds(2);
        slime_start_hop = false;
    }
}
