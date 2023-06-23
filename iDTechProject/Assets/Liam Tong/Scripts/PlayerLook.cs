using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //sensitivity
    public float sensX;
    public float sensY;

    public Transform orientation;

    //rotation of camera
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        //locks cursor in the middle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //this is how Unity works I don't understand either
        yRotation += mouseX;
        xRotation -= mouseY;

        //limit look up/down to 90 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate camera along its own x axis (up and down)
        transform.localEulerAngles = Vector3.right * xRotation;

        //rotate camera and player along y axis (left and right)
        orientation.Rotate(Vector3.up * mouseX);
    }
}
