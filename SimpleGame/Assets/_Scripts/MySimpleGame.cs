using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySimpleGame : MonoBehaviour {

	// Use this for initialization
    public float speed = 30f;
    public float JumpSpeed = 10f;
    public CharacterController myController;
    public Transform CameraTransform;
    public float gravityStrength=5f;
    bool canJump = false;
    float verticalVelocity;

	void Update () {
        
        Vector3 myVector=new Vector3(0,0,0);
        myVector.x = Input.GetAxis("Horizontal");
        myVector.z = Input.GetAxis("Vertical");
        //myVector.y = 9001;
        myVector = Vector3.ClampMagnitude(myVector, 1f);
        myVector = myVector * speed*Time.deltaTime;

        Quaternion inputRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(CameraTransform.forward, Vector3.up), Vector3.up);
        myVector = inputRotation * myVector;
        verticalVelocity = verticalVelocity-gravityStrength*Time.deltaTime;
        if(Input.GetButtonDown("Jump"))
        {
            if (canJump)
            {
                verticalVelocity += JumpSpeed;
                
            }
        }
        myVector.y = verticalVelocity*Time.deltaTime;
        CollisionFlags flags =  myController.Move(myVector);
        
        if((flags & CollisionFlags.Sides|CollisionFlags.Below)!=0)
        {
            canJump = true;
            verticalVelocity = -3f;
        }
        else
        {
            canJump = false;
        }

	}
}
