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

    
    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(deltaTime < 0.1f ) { deltaTime += Time.deltaTime; return; } // ��������
        if (Input.anyKey) { deltaTime = 0; }

        if (Input.GetKey(KeyCode.Space))           // ��������          //Добавить частицу
        {
            
            SpawnParticle(Color.red, "red");
        }

        if (Input.GetKey(KeyCode.LeftShift))                            //�������� ����������
        {
           ParticleController.DeleteLastParticle();                        //удаление последней частицы
        }

        if (Input.GetKey(KeyCode.LeftControl))                         //�������� ���� ��������
        {

            ParticleController.DeleteAllParticle();                     //удаление всех частиц

        }
    }






    public void SpawnParticle(Color clr, string str)
    { 
        GameObject temp = Instantiate(Prefub,transform.position, UnityEngine.Quaternion.identity);

        ParticleController.addParticle(temp, clr, str);


    }
}
