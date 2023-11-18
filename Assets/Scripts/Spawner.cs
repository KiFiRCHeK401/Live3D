using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static double deltaTime = 0;
    public GameObject Prefub;
    
    


    // Update is called once per frame
    private void Update()
    {
        
        if(deltaTime < 0.1f ) { deltaTime += Time.deltaTime; return; } // ��������
        if (Input.anyKey) { deltaTime = 0; }

        if (Input.GetKey(KeyCode.Space))           // ��������          //Добавить частицу
        {

            UnityEngine.Vector3 firstAngle = new UnityEngine.Vector3(0.3f,0.3f,0.3f);
            UnityEngine.Vector3 secondAngle = new UnityEngine.Vector3(-0.3f,-0.3f,-0.3f);
            UnityEngine.Vector3 thrust = new UnityEngine.Vector3(5,5,5);
            for(int i=0;i<100;i++)
            {
                UnityEngine.Vector3 pos = GeneratePosition(firstAngle,secondAngle);
                SpawnParticle(pos, thrust,1);
            }
        }


        if (Input.GetKey(KeyCode.LeftControl))                         //�������� ���� ��������
        {

            ParticleController.DeleteAllParticle();                     //удаление всех частиц

        }
    }



    // public void SpawnParticle1(UnityEngine.Vector3 pos , UnityEngine.Vector3 thrust , int count)
    // {
    //     UnityEngine.Vector3 firstAngle = new UnityEngine.Vector3(0.3f,0.3f,0.3f);
    //     UnityEngine.Vector3 secondAngle = new UnityEngine.Vector3(0.3f,0.3f,0.3f);
        

    //     for(int i=0;i<100;i++)
    //     {
    //         UnityEngine.Vector3 pos = GeneratePosition(firstAngle,secondAngle);
    //         SpawnParticle(pos, thrust,1);
    //     }
        
    // }







    public UnityEngine.Vector3 GeneratePosition(UnityEngine.Vector3 firstAngle, UnityEngine.Vector3 secondAngle)
    {
        System.Random rnd = new System.Random();

        float x;    
        float y;
        float z;

        x = (float)rnd.NextDouble()*(firstAngle.x-secondAngle.x)+secondAngle.x;
        y = (float)rnd.NextDouble()*(firstAngle.y-secondAngle.y)+secondAngle.y;
        z = (float)rnd.NextDouble()*(firstAngle.z-secondAngle.z)+secondAngle.z;
        return new UnityEngine.Vector3(x,y,z);
    }
    public void SpawnParticle(UnityEngine.Vector3 position, UnityEngine.Vector3 thrust, int type)
    { 
        GameObject temp = Instantiate(Prefub,position, UnityEngine.Quaternion.identity);
        ParticleController.addParticle(temp, thrust, type);

    }
}
