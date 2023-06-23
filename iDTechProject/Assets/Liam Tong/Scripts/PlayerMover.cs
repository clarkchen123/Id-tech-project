using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GOES WITH PlayerController script!

//Takes the axis direction of the input (left right up down jump) from PlayerController and move the player in that direction respectively.

[RequireComponent(typeof(Rigidbody))] //Tells any component this is put on that it requires a Rigidbody component
public class PlayerMover : MonoBehaviour
{
    Rigidbody rb;

    public float speed = 10.0f;
    public float jumpForce = 8.0f;
    public int maxAirJumpCount;
    private int remainingAirJump;

    //bool jumping = false;
    
    private float distToGround; //to check if player is on ground

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //intialize Rigidbody

        distToGround = GetComponent<Collider>().bounds.extents.y; //get distance to ground

        remainingAirJump = maxAirJumpCount;
    }

    public void MoveLeftRight(float axis)
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * axis);
    }

    public void MoveForwardBackward(float axis)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * axis);
    }

    public void Jump()
    {
        if (IsGrounded()) //resets remainingAirJump
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //jumping = true;
            remainingAirJump = maxAirJumpCount;
        }
        else if (!IsGrounded() && remainingAirJump != 0)
        {
            remainingAirJump--;
            //jumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }

    private bool IsGrounded() //checks if player is grounded
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.05f);
    }


    void Update()
    {
        if (rb.position.y <= -10.0f)
        {
            GameManager.Instance.LoadLevel(FindObjectOfType<GameManager>().currentBuildIndex); //reloads level/restart
        }  
    }
   
}
