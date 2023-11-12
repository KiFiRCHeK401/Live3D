using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public double deltaTime = 0;
    public GameObject Prefub;
    public HashSet<GameObject> particles = new HashSet<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(deltaTime < 0.1f ) { deltaTime += Time.deltaTime; return; }
        if (Input.anyKey) { deltaTime = 0; }

        if (Input.GetKey(KeyCode.Space))
        {
            particles.Add(Instantiate(Prefub, transform.position, UnityEngine.Quaternion.identity));
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Destroy(particles.Last());
            particles.Remove(particles.Last());
        }
        if ( Input.GetKey(KeyCode.LeftControl))
        {
            foreach (GameObject body in particles) {
                Destroy(body);
            }
            particles.Clear();
        }
    }


    



    public void SpawnParticle()
    {
        particles.Add(Instantiate(Prefub, transform.position, UnityEngine.Quaternion.identity));
    }
}
