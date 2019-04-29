using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xboxRotate : MonoBehaviour
{
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    public float minFov = 15f;
    public float maxFov = 90f;
    public float sensitivity = 10f;

    void Update()
    {
        // Rotate Left to Right
        float rotation = Input.GetAxis("LeftJoystickHorizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        
        // Zoom In and Out
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("RightJoystickVertical") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
