using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ParticleController : ParticleBase
{
    // Start is called before the first frame update

    [SerializeField] public List<TMP_InputField> _matrix = new List<TMP_InputField>();




    public void GetMatrix(List<TMP_InputField> temp)
    {
        


    }



    private void Start()
    {
        Application.targetFrameRate = 144;
    }

    private void Update()
    {
        Thrust();

    }


    private void Thrust()
    {
        _matrix = SendMatrix.Sender;





        // добавить отношения
        foreach (GameObject _this in IncludedRigidbodies)
        {
            
            float s = 0.4f; //первая точка
            float c = 4f; //вторая точка 
            float d = 10f;//конечная точка



            double distanse = Math.Pow(_this.transform.position.x - this.transform.position.x, 2);
            distanse += Math.Pow(_this.transform.position.y - this.transform.position.y, 2);
            distanse += Math.Pow(_this.transform.position.z - this.transform.position.z, 2);
            distanse = Math.Pow(distanse, 0.5);


            //double targetWeight = 1;
            Vector3 vector = (_this.transform.position - this.transform.position).normalized;
            double targetWeight = Convert.ToDouble(_matrix[this.type * 4 + _this.GetComponent<ParticleBase>().type].text);

            ////          Debug.Log(vector.x);

            if (distanse < s)
            {
                vector = new Vector3((float)(vector.x * (distanse - s)), (float)(vector.y * (distanse - s)), (float)(vector.z * (distanse - s)));
            }
            else if (distanse < c)
            {
                vector = new Vector3((float)(2 * targetWeight * vector.x * (distanse - s)), (float)(2 * targetWeight * vector.y * (distanse - s)), (float)(2 * targetWeight * vector.z * (distanse - s)));
            }
            else
            {
                vector = new Vector3((float)(-1 * targetWeight * vector.x * (distanse - d)), (float)(-1 * targetWeight * vector.y * (distanse - d)), (float)(-1 * targetWeight * vector.z * (distanse - d)));
            }




            ////vector = new Vector3((float)(vector.x / distanse * targetWeight), (float)(vector.y / distanse * targetWeight), (float)(vector.z / distanse * targetWeight));
            int correct = 1;
            vector = new Vector3(vector.x / correct, vector.y / correct, vector.z / correct);


            GetComponent<Rigidbody>().AddForce(vector);
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.99f;

            //this.transform.position = this.transform.position + vector;


        }

    }
}
