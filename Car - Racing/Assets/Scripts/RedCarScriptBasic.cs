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

    public Quaternion quaternion;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Car2h");
        verticalInput = Input.GetAxis("Car2v");
        Debug.Log(verticalInput * motorForce);
        isBreaking = Input.GetKey(KeyCode.Space);

        currentbreakForce = isBreaking ? breakForce : 0f;

        frontLeftWheelCollider.motorTorque = (verticalInput * motorForce);
        frontRightWheelCollider.motorTorque = (verticalInput * motorForce);

        Debug.Log(frontRightWheelCollider.motorTorque);

        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;

        // 
        float currentSteerAngle;
        currentSteerAngle = 10 * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }
}
