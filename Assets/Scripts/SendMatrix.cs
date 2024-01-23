using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SendMatrix : MonoBehaviour
{

    [SerializeField] public List<TMP_InputField> _matrix = new List<TMP_InputField>();

    public static List<TMP_InputField> Sender;

    private double deltaTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        Sender = _matrix;
    }

    // Update is called once per frame
    void Update()
    {
        if (deltaTime < 1f) { deltaTime += Time.deltaTime; return; } 
        if (Input.anyKey)
        {
            deltaTime = 0;
            Sender = _matrix;
        }
        
    }

    //public void SendMatrix_()
    //{
    //    GetComponent<ParticleController>().GetMatrix(_matrix);
    //    Debug.Log("Отправлено");
    //}



}
