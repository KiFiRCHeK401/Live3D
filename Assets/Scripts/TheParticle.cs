using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TheParticle : MonoBehaviour
{

    private GameObject obj;
    private Color ColorType;
    public HashSet<Rigidbody> IncludedRigidbodies = new HashSet<Rigidbody>();



    public TheParticle(GameObject objct, Color ColorType,string typeName)
    {
        this.obj = objct;
        this.ColorType = ColorType;
        //this.GetComponent<Renderer>().material.SetColor(typeName, ColorType);
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
