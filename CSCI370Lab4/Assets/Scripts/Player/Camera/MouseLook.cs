using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float MouseSensitivity = 100f;

    public Transform playerBody;

    private Camera myCam;

    // Start is called before the first frame update
    void Start()
    {
        myCam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        myCam.orthographicSize = (Screen.height / 100f);

        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        /*float z = Input.GetAxis("Horizontal") * MouseSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.forward * z);*/
        playerBody.Rotate(Vector3.up * mouseX);
        playerBody.Rotate(Vector3.right * mouseY);
    }
}
