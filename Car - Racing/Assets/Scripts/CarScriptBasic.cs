using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScriptBasic : MonoBehaviour
{
    private float horizontalInput, verticalInput, currentbreakForce;
    private bool isBreaking;
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;

    [SerializeField] public WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    public float maxSpeed = 80;
    public Quaternion quaternion;
    public Rigidbody rigidBody;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = -Input.GetAxis("Vertical");

        float forwardSpeed = Vector3.Dot(transform.forward, rigidBody.velocity);


        // Calculate how close the car is to top speed
        // as a number from zero to one
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, forwardSpeed-5);

        // Use that to calculate how much torque is available 
        // (zero torque at top speed)
        float currentMotorTorque = Mathf.Lerp(motorForce, 0, speedFactor);
        

        isBreaking = Input.GetKey(KeyCode.Space);

        currentbreakForce = isBreaking ? breakForce : 0f;

        frontLeftWheelCollider.motorTorque = verticalInput * currentMotorTorque;
        frontRightWheelCollider.motorTorque = verticalInput * currentMotorTorque;

        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;

// 
        float currentSteerAngle;
        currentSteerAngle = 13 * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }
}
