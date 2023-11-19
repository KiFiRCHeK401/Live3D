using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public static double deltaTime = 0;
    public List<GameObject> Prefubs;
    public GameObject MainCamera;
    public TMP_InputField Amount;
    public TMP_InputField StartSpeed;
    public TMP_InputField SizeSpawnZone;
    public Toggle useCameraForSpawn;

    private GameObject prefub;

    UnityEngine.Vector3 spawnPos = new UnityEngine.Vector3(0,0,0);

    


    // Update is called once per frame
    private void Update()
    {
        if(ShowPanel.open)
        {
            return;
        }
        
        if(deltaTime < 0.1f ) { deltaTime += Time.deltaTime; return; } // ��������
        if (Input.anyKey) { 
            if(Input.GetKey(KeyCode.Alpha1)||Input.GetKey(KeyCode.Alpha2)||Input.GetKey(KeyCode.Alpha3)||Input.GetKey(KeyCode.Alpha4)||Input.GetKey(KeyCode.LeftControl))
            {
                deltaTime = 0;
            }
            else return;
         }
        else {
            deltaTime = 1;
            return;
        }

        int type =0;
        int count = Math.Abs(Convert.ToInt32(Amount.text));
        float sizeZone = (float)Math.Abs(Convert.ToDouble(SizeSpawnZone.text));
        
        if (Input.GetKey(KeyCode.Alpha1))           // ��������          
        {
            type = 1;
            prefub = Prefubs[0];
        }
        if (Input.GetKey(KeyCode.Alpha2))           // ��������          
        {
            type = 2;
            prefub = Prefubs[1];
        }
        if (Input.GetKey(KeyCode.Alpha3))           // ��������          
        {
            type = 3;
            prefub = Prefubs[2];
        }
        if (Input.GetKey(KeyCode.Alpha4))           // ��������          
        {
            type = 4;
            prefub = Prefubs[3];
        }

        if(useCameraForSpawn.isOn)
        {
            spawnPos = MainCamera.transform.position;
        }
        if(!useCameraForSpawn.isOn)
        {
            spawnPos = new UnityEngine.Vector3(0,0,0);
        } 
    
        UnityEngine.Vector3 pos1 = new UnityEngine.Vector3(spawnPos.x+sizeZone,spawnPos.y+sizeZone,spawnPos.z+sizeZone);
        UnityEngine.Vector3 pos2 = new UnityEngine.Vector3(spawnPos.x-sizeZone,spawnPos.y-sizeZone,spawnPos.z-sizeZone);

        for(int i=0;i<count;i++)
        {
            SpawnParticle(GeneratePosition(pos1,pos2),GetStartVelosity(),type);
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





private UnityEngine.Vector3 GetStartVelosity(){
    UnityEngine.Vector3 StartVector = MainCamera.transform.forward;
    float Speed=0;
    if((float)Convert.ToDouble(StartSpeed.text)<0){Speed = 0;}
    else Speed = (float)Convert.ToDouble(StartSpeed.text);

    StartVector =  Speed*StartVector;

    return StartVector;
}


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
        GameObject temp = Instantiate(prefub,position, UnityEngine.Quaternion.identity);
        ParticleController.addParticle(temp, thrust, type);

    }
}
