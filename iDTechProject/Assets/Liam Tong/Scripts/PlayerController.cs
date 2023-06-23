using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// GOES WITH PlayerMover script!

//This script is used to constantly check for player input, either using keyboard or controller.
//Records the axis of movement (up or down, left or right) and assigning it to a variable (XMove, YMove, jump)


[System.Serializable] //Allows the class below to be seen and edited in UnityEditor
public class MoveEvent : UnityEvent<float> {} //A public class that takes all of its information from a UnityEvent that takes a float number
public class PlayerController : MonoBehaviour
{
    public MoveEvent XMove; //gets info from a UnityEvent that takes a float
    public MoveEvent YMove; //gets info from a UnityEvent that takes a float
    public UnityEvent onJumpPressed; //not MoveEvent because we don't need to know which axis (jump is only up)

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal")) //using ubity input system
        {
            XMove.Invoke(Input.GetAxis("Horizontal")); //Records the axis of horizontal movement (left or right)
        }

        if (Input.GetButton("Vertical"))
        {
            YMove.Invoke(Input.GetAxis("Vertical")); //Records the axis of vertical movement (up or down)
        }

        if (Input.GetButtonDown("Jump")) //GetButtonDown because we don't need to continuously check for jump when pkayer is already midair
        {
            onJumpPressed.Invoke();
        }
    }
}
