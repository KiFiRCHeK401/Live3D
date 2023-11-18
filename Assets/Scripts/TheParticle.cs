using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TheParticle : MonoBehaviour
{
    private List<Color> colors =new List<Color>{Color.red,Color.blue,Color.white,Color.black, Color.yellow};
    private GameObject obj;
    private int type;
    public HashSet<Rigidbody> IncludedRigidbodies = new HashSet<Rigidbody>();



    public TheParticle(GameObject objct, UnityEngine.Vector3 thrust, int type)
    {
        this.obj = objct;
        this.type = type;
        this.obj.GetComponent<Rigidbody>().AddForce(thrust);
    


        //this.GetComponent<MeshRenderer>().material.SetColor("Material1",colors[type]);
    }
    ~TheParticle()
    {
        //��������� �� �������� �������
    }


    public void DeleteParticle()
    {

        IncludedRigidbodies.Clear();
        Destroy(this.obj);
    }



    //public void SetType(Color ColorType)
    //{
    //    this.ColorType = ColorType;
    //    this.GetComponent<Renderer>().material.SetColor("red", Color.red);

    //}


}
