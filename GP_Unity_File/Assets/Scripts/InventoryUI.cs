using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateOrbText(PlayerInventory playerInventory)
    {
        Score.text = "score : " + playerInventory.NumOfOrbs.ToString();
    }
}
