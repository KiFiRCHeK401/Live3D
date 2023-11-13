using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamMuvie : MonoBehaviour
{

    float Speed = 0.04f;
    float maxSpeed = 0.04f;
    float thrust = 0.01f;
    Vector3 targetVector = new Vector3(0,0,0);
    Vector3 motionVector = new Vector3(0, 0, 0);
    

    Vector3 lastMousePos = Vector3.zero;
    float camSens = 0.25f;

    public float cosX;
    public float cosY;
    public float cosZ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CamControl();

        CamMuve();

        CamRotate();
    }





    private void CamControl() //оброботка нажатий кнопок управления камерой

    {
        if (!Input.anyKey)
        {
            motionVector = new Vector3(motionVector.x + (targetVector.x - motionVector.x) * thrust, motionVector.y + (targetVector.y - motionVector.y) * thrust, motionVector.z + (targetVector.z - motionVector.z) * thrust);
            return;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = Speed * 0.1f;
        }
        else maxSpeed = Speed;
        
        if (Input.GetKey(KeyCode.W))
        {
            targetVector += new Vector3(0, 0, maxSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            targetVector += new Vector3(0, 0, -maxSpeed);
        }
        if (Input.GetKey(KeyCode.R))
        {
            targetVector += new Vector3(0, maxSpeed, 0);
        }
        if (Input.GetKey(KeyCode.F))
        {
            targetVector += new Vector3(0, -maxSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            targetVector += new Vector3(maxSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            targetVector += new Vector3(-maxSpeed, 0, 0);
        }







        motionVector = new Vector3(motionVector.x + (targetVector.x - motionVector.x) * thrust, motionVector.y + (targetVector.y - motionVector.y) * thrust, motionVector.z + (targetVector.z - motionVector.z) * thrust);
        targetVector = new Vector3(0, 0, 0);
    }


    //private void Thrust()
    //{
    //    if((targetSpeed - currentSpeed)*1000<(maxSpeed))
    //        currentSpeed = 0;
    //    else 
    //        currentSpeed = currentSpeed + (targetSpeed - currentSpeed) * thrust;
    //}



    private void CamRotate()
    {
        lastMousePos = Input.mousePosition - lastMousePos;
        lastMousePos = new Vector3(-lastMousePos.y * camSens, lastMousePos.x * camSens, 0);                                 //знаю что так делать не хорошо
        lastMousePos = new Vector3(transform.eulerAngles.x + lastMousePos.x, transform.eulerAngles.y + lastMousePos.y, 0);  //но я сделал
        transform.eulerAngles = lastMousePos;
        lastMousePos = Input.mousePosition;                                                                                 //и никто меня не остановил
    }
    private void CamMuve()
    {
        cosX = (float)Math.Cos(transform.eulerAngles.x);
        cosY = (float)Math.Cos(transform.eulerAngles.y);
        cosZ = (float)Math.Cos(transform.eulerAngles.z);
        //transform.position = Camera.main.transform.TransformDirection(transform.position + motionVector);
        transform.position = new Vector3(transform.position.x + cosY * motionVector.x, 0, 0); 
        // нужно расчитывать позицию камеры умножая косинусы синусы хуинусы на вектор и прибавлять текущуюю позицию



    }

    public void SetMaxSpeed(double Max)
    {
        
    }
}
