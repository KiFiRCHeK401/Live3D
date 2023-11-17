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



    public TheParticle(GameObject obj, Color ColorType,string typeName)
    {
        this.obj = obj;
        //this.ColorType = ColorType;
        //this.GetComponent<Renderer>().material.SetColor(typeName, ColorType);
    }
    ~TheParticle()
    {
        //сообщение об удалении частицы
    }


    public void DeleteParticle()
    {
        Destroy(this.obj);
    }



    //public void SetType(Color ColorType)
    //{
    //    this.ColorType = ColorType;
    //    this.GetComponent<Renderer>().material.SetColor("red", Color.red);

    //}


}
