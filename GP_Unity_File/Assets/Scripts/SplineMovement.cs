using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class SplineMovement : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointC;
    [SerializeField] private Transform pointD;
    [SerializeField] private Transform pointE;
    [SerializeField] private Transform pointF;
    [SerializeField] private Transform pointAB;
    [SerializeField] private Transform pointBC;
    [SerializeField] private Transform pointCD;
    [SerializeField] private Transform pointDE;
    [SerializeField] private Transform pointEF;
    [SerializeField] private Transform pointAB_BC;
    [SerializeField] private Transform pointBC_CD;
    [SerializeField] private Transform pointCD_DE;
    [SerializeField] private Transform pointDE_EF;
    [SerializeField] private Transform pointABCD;
    [SerializeField] private Transform pointCDEF;
    [SerializeField] private Transform pointABCDEF;
    [SerializeField] private Transform Barrel1;
    private float interpolateAmount;

    private Vector3 gizmoPos;
    public bool barrelIsActive = false;

    
  

    private void FixedUpdate()
    {
        if (barrelIsActive)
        {
            interpolateAmount = (interpolateAmount + Time.deltaTime / 40) % 5f;
        }
        pointAB.position = Vector3.Lerp(pointA.position, pointB.position, interpolateAmount);
        pointBC.position = Vector3.Lerp(pointB.position, pointC.position, interpolateAmount);
        pointCD.position = Vector3.Lerp(pointC.position, pointD.position, interpolateAmount);
        pointDE.position = Vector3.Lerp(pointD.position, pointE.position, interpolateAmount);
        pointEF.position = Vector3.Lerp(pointE.position, pointF.position, interpolateAmount);
        pointAB_BC.position = Vector3.Lerp(pointAB.position, pointBC.position, interpolateAmount);
        pointBC_CD.position = Vector3.Lerp(pointBC.position, pointCD.position, interpolateAmount);
        pointCD_DE.position = Vector3.Lerp(pointCD.position, pointDE.position, interpolateAmount);
        pointDE_EF.position = Vector3.Lerp(pointDE.position, pointEF.position, interpolateAmount);
        pointABCD.position = Vector3.Lerp(pointAB.position, pointCD.position, interpolateAmount);
        pointCDEF.position = Vector3.Lerp(pointCD.position, pointEF.position, interpolateAmount);
        Barrel1.position = Vector3.Lerp(pointABCD.position, pointCDEF.position, interpolateAmount);
     // pointABCDEF.position = Vector3.Lerp(pointABCD.position, pointCDEF.position, interpolateAmount);


    }

    private void OnDrawGizmos()
    {
        float gizmoOffset = 0.0f;
        for(float t = 0; t <= 1; t += 0.005f)
        {
            gizmoOffset = gizmoOffset + 0.01f;
            pointAB.position = Vector3.Lerp(pointA.position, pointB.position, gizmoOffset);
            pointBC.position = Vector3.Lerp(pointB.position, pointC.position, gizmoOffset);
            pointCD.position = Vector3.Lerp(pointC.position, pointD.position, gizmoOffset);
            pointDE.position = Vector3.Lerp(pointD.position, pointE.position, gizmoOffset);
            pointEF.position = Vector3.Lerp(pointE.position, pointF.position, gizmoOffset);
            pointAB_BC.position = Vector3.Lerp(pointAB.position, pointBC.position, gizmoOffset);
            pointBC_CD.position = Vector3.Lerp(pointBC.position, pointCD.position, gizmoOffset);
            pointCD_DE.position = Vector3.Lerp(pointCD.position, pointDE.position, gizmoOffset);
            pointDE_EF.position = Vector3.Lerp(pointDE.position, pointEF.position, gizmoOffset);
            pointABCD.position = Vector3.Lerp(pointAB.position, pointCD.position, gizmoOffset);
            pointCDEF.position = Vector3.Lerp(pointCD.position, pointEF.position, gizmoOffset);
            gizmoPos = Vector3.Lerp(pointABCD.position, pointCDEF.position, gizmoOffset);
            Gizmos.DrawSphere(gizmoPos, 0.25f);
        }
    }
    
}

