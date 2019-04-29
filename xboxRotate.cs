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
    public float rotationX = 0f;
    public float rotationY = 90f;
    public float sensitivityX = 2f;
    public float sensitivityY = 2f;
    public float lockPos = 0;

    void Update()
    {

        // Rotate Left to Right
        rotationY += Input.GetAxis("LeftJoystickHorizontal") * sensitivityY;

        // Rotate Up and Down
        rotationX += Input.GetAxis("LeftJoystickVertical") * sensitivityX;
        rotationX = Mathf.Clamp (rotationX, -50, 40);
        
        // Vertical Boundaries
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, lockPos);
        transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0f);

        // Zoom In and Out
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("RightJoystickVertical") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
