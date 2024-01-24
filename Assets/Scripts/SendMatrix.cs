using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

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


    public void SaveMtrx()
    {
        string str = "";
        foreach (TMP_InputField tmp in _matrix)
        {
            str += tmp.text+"|"; ;
        }
        PlayerPrefs.SetString("matrix",str);

    }


    public void UpLoad()
    {
        string str = PlayerPrefs.GetString("matrix");
        List<string> list = str.Split(new string[] { "|" }, StringSplitOptions.None).ToList();

        int i = 0;

        foreach (string str2 in list)
        {
            _matrix[i].text = str2;
            i++;
        }
    }




    //рандомная генерация матрицы
}
