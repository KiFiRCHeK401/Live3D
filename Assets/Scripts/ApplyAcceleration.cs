using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ApplyAcceleration : MonoBehaviour
{
    public static List<TheParticle> TheParticles;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void addParticle(GameObject obj, Color color, string name)
    {
        TheParticles.Add(new TheParticle(obj, color, name));
    }

    public static void DeleteParticle()
    {
        TheParticles[TheParticles.Count()-1].DeleteParticle();
        TheParticles.Remove(TheParticles[TheParticles.Count() - 1]);
    }


    public static void DeleteAllParticle()
    {
        foreach (TheParticle body in TheParticles)
        {
            body.DeleteParticle();  
        }
        TheParticles.Clear();
    }


}
