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
        
        if(deltaTime < 0.1f ) { deltaTime += Time.deltaTime; return; } // задержка
        if (Input.anyKey) { deltaTime = 0; }

        if (Input.GetKey(KeyCode.Space))           // создание
        {
            SpawnParticle(Color.red, "red");
        }

        if (Input.GetKey(KeyCode.LeftShift))                            //удаление последнего
        {
            ApplyAcceleration.DeleteParticle();
        }

        if (Input.GetKey(KeyCode.LeftControl))                         //удаление всех обьектов
        {

            ApplyAcceleration.DeleteAllParticle();

        }
    }






    public void SpawnParticle(Color clr, string str)
    { 


        ApplyAcceleration.addParticle(Instantiate(Prefub,transform.position, UnityEngine.Quaternion.identity), clr, str);


    }
}
