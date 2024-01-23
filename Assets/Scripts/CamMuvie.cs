using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamMuvie : MonoBehaviour
{
    public static int test;

    private static float Speed = 0.04f;
    private static float maxSpeed = 0.04f;
    private static float  thrust = 0.01f;
    private static Vector3 targetVector = new Vector3(0,0,0);
    public static Vector3 motionVector = new Vector3(0, 0, 0);
    

    Vector3 lastMousePos = Vector3.zero;
    float camSens = 0.15f;

    public float cosX;
    public float cosY;
    public float cosZ;

    public float sinX;
    public float sinY;
    public float sinZ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(ShowPanel.open)
        {
            return;
        }
        
        CamControl();

        CamMuve();

        CamRotate();
    }





    private void CamControl() //��������� ������� ������ ���������� �������

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
            targetVector += transform.forward*maxSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            targetVector += transform.forward * -maxSpeed;
        }
        if (Input.GetKey(KeyCode.R))
        {
            targetVector += transform.up * maxSpeed;
        }
        if (Input.GetKey(KeyCode.F))
        {
            targetVector += transform.up * -maxSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            targetVector += transform.right * maxSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            targetVector += transform.right * -maxSpeed;
        }


        motionVector = new Vector3(motionVector.x + (targetVector.x - motionVector.x) * thrust, motionVector.y + (targetVector.y - motionVector.y) * thrust, motionVector.z + (targetVector.z - motionVector.z) * thrust);
        targetVector = new Vector3(0, 0, 0);
    }


    private void CamRotate()
    {
        
        lastMousePos = Input.mousePosition - lastMousePos;
        lastMousePos = new Vector3(-lastMousePos.y * camSens, lastMousePos.x * camSens, 0);                                 //���� ��� ��� ������ �� ������
        lastMousePos = new Vector3(transform.eulerAngles.x + lastMousePos.x, transform.eulerAngles.y + lastMousePos.y, 0);  //�� � ������
        transform.eulerAngles = lastMousePos;
        lastMousePos = Input.mousePosition;                                                                                 //� ����� ���� �� ���������
    }
    private void CamMuve()
    {
        transform.position = (transform.position + motionVector);

        //cosX = (float)Math.Cos((Math.PI / 180) * transform.eulerAngles.x);
        //cosY = (float)Math.Cos((Math.PI / 180) * transform.eulerAngles.y);
        ////cosZ = (float)Math.Cos((Math.PI / 180) * transform.eulerAngles.z);

        //sinX = (float)Math.Sin((Math.PI / 180) * transform.eulerAngles.x);
        //sinY = (float)Math.Sin((Math.PI / 180) * transform.eulerAngles.y);
        ////sinZ = (float)Math.Sin((Math.PI / 180) * transform.eulerAngles.z);

        //float x = 0;
        //float y = 0;
        //float z = 0;


        ////x = transform.position.x + cosY * motionVector.x + sinY * motionVector.z + sinX * motionVector.y;       //gorizontal
        ////y = transform.position.y + cosX * motionVector.y + sinY * motionVector.z + sinX * motionVector.y;       //vertical
        ////z = transform.position.z + cosY * motionVector.z + sinX * motionVector.y + sinX * motionVector.y;       //gorisontal


        //transform.position = ;

        //transform.position = new Vector3(x, y, z);

        //.position = new Vector3(transform.position.x + cosY * motionVector.x, 0, 0); 
        // ����� ����������� ������� ������ ������� �������� ������ ������� �� ������ � ���������� �������� �������



    }

    public void SetMaxSpeed(double Max)
    {
        
    }
}
