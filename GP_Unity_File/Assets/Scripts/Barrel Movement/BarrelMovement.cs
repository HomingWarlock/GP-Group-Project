
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BarrelMovement : MonoBehaviour
{
  public float underWaterDrag = 3f;
  public float underWaterAngularDrag = 1f;
  public float airDrag = 0f;
  public float airAngularDrag = 0.05f;

  public float floatingPower = 15f;
  public float waterHeight = 0f;
  Rigidbody b_Rigidbody;

  bool underWater;

  private void Start()
  {
    b_Rigidbody = GetComponent<Rigidbody>();
  }

  private void FixedUpdate()
  {
    float difference = transform.position.y - waterHeight;
    if (difference < 0)
    {
      b_Rigidbody.AddForceAtPosition
      (Vector3.up * floatingPower * Mathf.Abs(difference),
        transform.position, ForceMode.Force);
      if (!underWater)
      {
        underWater = true;
      }
      else if (underWater)
      {
        underWater = false;
        SwitchState(false);
      }
    }

    void SwitchState(bool isUnderWater)
    {
      if (underWater)
      {
        b_Rigidbody.drag = underWaterDrag;
        b_Rigidbody.angularDrag = underWaterDrag;
      }
      else
      {
        b_Rigidbody.drag = airDrag;
        b_Rigidbody.angularDrag = airAngularDrag;

      }
    }
  }
}
