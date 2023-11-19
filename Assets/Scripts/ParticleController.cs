using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParticleController : MonoBehaviour
{
    public TMP_Text countParticles;
    public static List<TheParticle> theParticles = new List<TheParticle>();
    public List<TMP_InputField> matrix;
    //public static List<TheParticle> testList = new List<TheParticle>();

    private void Update()
    {
        //countParticles.text = theParticles.Count.ToString();
        Calculate();
    }

    // private void OnTriggerEnter(Collider other){
    //     countParticles.text = "yes";
    // }


    private void Calculate()
    {
        

        for(int i=0;i<theParticles.Count-1;i++)
        {

        }
    }

    public static void DeleteLastParticle()                                    //Удаление последней частицы
    {
        if(theParticles.Count>0)
        {
            theParticles[theParticles.Count-1].DeleteParticle();
            theParticles.Remove(theParticles[theParticles.Count-1]);
        }

    }
    public static void DeleteAllParticle()                                     //удаление всех частиц
    {
        foreach(TheParticle body in theParticles)
        {
            body.DeleteParticle();
        }
        theParticles.Clear();
    }

    public static void addParticle(GameObject obj, UnityEngine.Vector3 thrust, int type)
    {
        //testList.Add(new TheParticle(obj,color,str));
        theParticles.Add(new TheParticle(obj,thrust,type));
    }
}
