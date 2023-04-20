using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float cameraSmoothingTime = 0.1f;
    private float cameraRotationAmount = 0.0f;
    private float cameraRotationAngle = 0.0f;
    Vector3 offset;

    // Start is called before the first frame update
    void Awake()
    {
        offset = this.transform.position - player.transform.position;
    }


    public void OnLook(Vector2 CameraRotationVector)
    {
        if ((CameraRotationVector.x > -0.2) && (CameraRotationVector.x < 0.2))
        {
            cameraRotationAmount = 0.0f;
        }
        else 
        {
            if (CameraRotationVector.x <= -0.2)
            {
                cameraRotationAmount = -0.5f;
            }
            else if (CameraRotationVector.x >= 0.2)
            {
                cameraRotationAmount = 0.5f;
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraRotationAngle += cameraRotationAmount;
        Quaternion rotation = Quaternion.Euler(0, cameraRotationAngle, 0);
        this.transform.position = player.transform.position + offset;
        this.transform.RotateAround(player.transform.position, Vector3.up, cameraRotationAngle);
        this.transform.LookAt(player.transform);
    }
}
