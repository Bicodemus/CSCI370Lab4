using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float MouseSensitivity = 1000f;

    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        playerBody.Rotate(Vector3.up * mouseX);
        playerBody.Rotate(Vector3.right * mouseY);
    }
}
