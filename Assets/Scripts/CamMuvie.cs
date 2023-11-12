using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMuvie : MonoBehaviour
{

    double maxSpeed = 0.0001;
    double targetSpeed = 0;
    double currentSpeed = 0;
    double thrust = 0.001;
    int fault = 10000;
    Vector3 motionVector=new Vector3(0,0,0);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CamControl();
        Thrust();
        Muve(motionVector, currentSpeed);
    }





    private void CamControl() //оброботка нажатий кнопок управления камерой

    {
        if (!Input.anyKey)
        {
            targetSpeed = 0;
            motionVector += new Vector3(0, 0, 0);
            return;
        }
        

        if (Input.GetKey(KeyCode.W))
        {
            targetSpeed = maxSpeed;
            motionVector += new Vector3(0, 0, 1);

        }







    }


    private void Thrust()
    {
        if((targetSpeed - currentSpeed)*1000<(maxSpeed))
            currentSpeed = 0;
        else 
            currentSpeed = currentSpeed + (targetSpeed - currentSpeed) * thrust;
    }


    private void Muve(Vector3 vector, double speed)
    {
        transform.position = transform.position + new Vector3(motionVector.y * (float)currentSpeed, motionVector.x * (float)currentSpeed, motionVector.z * (float)currentSpeed);
    }

    public void SetMaxSpeed(double Max)
    {
        
    }
}
