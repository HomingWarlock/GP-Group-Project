using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumOfOrbs { get; private set; }

    public UnityEvent<PlayerInventory> OnOrbCollected;

    public void OrbCollected()
    {
        NumOfOrbs++;
        OnOrbCollected.Invoke(this);
    }
}

