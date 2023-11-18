using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    
    public static List<TheParticle> theParticles = new List<TheParticle>();

    //public static List<TheParticle> testList = new List<TheParticle>();

    void Update()
    {
        //добавить всякие там ускорения и вхождения в поле взаимодействия
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
