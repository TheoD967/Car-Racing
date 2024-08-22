
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCarScriptBasic : MonoBehaviour
{
    private float horizontalInput, verticalInput, currentbreakForce;
    private bool isBreaking;
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;

    [SerializeField] public WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    public float maxSpeed = 80;
    public Quaternion quaternion;
    public Rigidbody rigidBody;
    private float backwards = 1;
    public float laps = 1;
    private bool finalCheck = false;
    private float Starttime;
    private float ElapsedTime;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "lap counter")
        {
            laps++;
            if (laps ==0) {
                Starttime = Time.time;
                Debug.Log(Starttime);
                Debug.Log(TrackMenuManager.Laps + 1);
               
            }
            
            if (laps == (TrackMenuManager.Laps+1)) {
                ElapsedTime = Time.time - Starttime;
                Debug.Log(ElapsedTime);
            }    
            
            Debug.Log(laps);
            finalCheck = false;
        }
        if (other.name == "final checkpoint")
        {
            finalCheck = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        backwards = 1;
        horizontalInput = Input.GetAxis("Car2h");
        verticalInput = -Input.GetAxis("Car2v");

        float forwardSpeed = Vector3.Dot(transform.forward, rigidBody.velocity);


        // Calculate how close the car is to top speed
        // as a number from zero to one
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, forwardSpeed - 5);

        // Use that to calculate how much torque is available 
        // (zero torque at top speed)
        float currentMotorTorque = Mathf.Lerp(motorForce, 0, speedFactor);


        
        isBreaking = Input.GetKey(KeyCode.Space);

        if (forwardSpeed > 1 && verticalInput > 0)
        {
            isBreaking = true;
            backwards = 0;
        }
            
        


        currentbreakForce = isBreaking ? breakForce : 0f;

        frontLeftWheelCollider.motorTorque = (verticalInput * currentMotorTorque) * backwards;
        frontRightWheelCollider.motorTorque = (verticalInput * currentMotorTorque) * backwards;

        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;

        // 
        float currentSteerAngle;
        currentSteerAngle = 13 * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }
}
