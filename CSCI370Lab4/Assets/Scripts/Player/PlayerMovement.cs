using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;
    public float speed = 12f;

    public float turnTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        float up = Input.GetAxisRaw("Up");

        Vector3 upDown = new Vector3(0f, up, 0f);
        Vector3 move = new Vector3(x, 0f, z).normalized;

        if (move.magnitude >= 0.1f)
        {
            float targetAng = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAng, ref turnSmoothVelocity, turnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            /*float targetAng2 = Mathf.Atan2(move.z, move.y) * Mathf.Rad2Deg + cam.eulerAngles.x;
            float angle2 = Mathf.SmoothDampAngle(transform.eulerAngles.x, targetAng2, ref turnSmoothVelocity, turnTime);
            transform.rotation = Quaternion.Euler(angle2, angle, 0f);


            Vector3 moveDirection = Quaternion.Euler(targetAng2, targetAng, 0f) * Vector3.forward;*/

            Vector3 moveDirection = Quaternion.Euler(0f, targetAng, 0f) * Vector3.forward; 
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        controller.Move(upDown * speed * Time.deltaTime);
    }
}
