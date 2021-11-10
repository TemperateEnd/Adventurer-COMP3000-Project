using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed;
    public float runSpeed;
    public bool canMove = true;

    [Space(5)]
    [Header("Rotation")]
    public Camera playerCam;
    public float rotateSpeed;
    public float rotateXBoundary;

    CharacterController charController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;


    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        //Locking cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool playerRunning = Input.GetButtonDown("Sprint");

        float currSpeedX = canMove ? (playerRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float currSpeedY = canMove ? (playerRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float moveDirectionY = moveDirection.y;
        moveDirection = (forward * currSpeedX) + (right * currSpeedY);

        charController.Move(moveDirection * Time.deltaTime);

        if(canMove)
        {
            rotationX += Input.GetAxis("Mouse Y") * rotateSpeed;
            rotationX = Mathf.Clamp(rotationX, -rotateXBoundary, rotateXBoundary);

            playerCam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);
        }
    }
}