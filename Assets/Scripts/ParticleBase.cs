using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using UnityEngine;


public class ParticleBase : MonoBehaviour
{
    



    public int type;
    public HashSet<GameObject> IncludedRigidbodies = new HashSet<GameObject>();
    public void DeleteParticle()
    {

        this.IncludedRigidbodies.Clear();
        Destroy(this);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        this.IncludedRigidbodies.Add(other.gameObject);


    }

    private void OnTriggerExit(Collider other)
    {
        this.IncludedRigidbodies.Remove(other.gameObject);

    }


    

}
