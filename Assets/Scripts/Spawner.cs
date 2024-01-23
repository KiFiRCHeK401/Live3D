using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private List<GameObject> PrefubParticle = new List<GameObject>();
    [SerializeField] private TMP_InputField Amount;
    [SerializeField] private TMP_InputField StartSpeed;
    [SerializeField] private TMP_InputField SizeSpawnZone;
    [SerializeField] private Toggle useCameraForSpawn;

    

    private HashSet<GameObject> particles = new HashSet<GameObject>();

    private double deltaTime = 0;

    UnityEngine.Vector3 spawnPos = new UnityEngine.Vector3(0, 0, 0);











    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AddParticle();
    }





    private void AddParticle()
    {
        GameObject prefub;

        if (ShowPanel.open)
        {
            return;
        }

        if (deltaTime < 0.1f) { deltaTime += Time.deltaTime; return; } // ��������
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.LeftControl))
            {
                deltaTime = 0;
            }
            else return;
        }
        else
        {
            deltaTime = 1;
            return;
        }

        int type = 0;
        int count = Math.Abs(Convert.ToInt32(Amount.text));
        float sizeZone = ((float)Math.Abs(Convert.ToDouble(SizeSpawnZone.text)))/2;

        if (Input.GetKey(KeyCode.Alpha1))           // ��������          
        {
            type = 1;
            prefub = PrefubParticle[0];
        }
        else if (Input.GetKey(KeyCode.Alpha2))           // ��������          
        {
            type = 2;
            prefub = PrefubParticle[1];
        }
        else if (Input.GetKey(KeyCode.Alpha3))           // ��������          
        {
            type = 3;
            prefub = PrefubParticle[2];
        }
        else if (Input.GetKey(KeyCode.Alpha4))           // ��������          
        {
            type = 4;
            prefub = PrefubParticle[3];
        }
        else if (Input.GetKey(KeyCode.LeftControl))                         //�������� ���� ��������
        {

            foreach (GameObject tmp in particles)
            {
                Destroy(tmp);
            }
            particles.Clear();
            return;
        }
        else
        {
            return;
        }

        if (useCameraForSpawn.isOn)
        {
            spawnPos = mainCamera.transform.position;
        }
        if (!useCameraForSpawn.isOn)
        {
            spawnPos = new UnityEngine.Vector3(0, 0, 0);
        }

        UnityEngine.Vector3 pos1 = new UnityEngine.Vector3(spawnPos.x + sizeZone, spawnPos.y + sizeZone, spawnPos.z + sizeZone);
        UnityEngine.Vector3 pos2 = new UnityEngine.Vector3(spawnPos.x - sizeZone, spawnPos.y - sizeZone, spawnPos.z - sizeZone);

        for (int i = 0; i < count; i++)
        {
            SpawnParticle(GeneratePosition(pos1, pos2), GetStartVelosity(), type, prefub);
        }

        
    }






    private UnityEngine.Vector3 GetStartVelosity()
    {
        UnityEngine.Vector3 StartVector = mainCamera.transform.forward;
        float Speed = 0;
        if ((float)Convert.ToDouble(StartSpeed.text) < 0) { Speed = 0; }
        else Speed = (float)Convert.ToDouble(StartSpeed.text);

        StartVector = Speed * StartVector;

        return StartVector;
    }


    public UnityEngine.Vector3 GeneratePosition(UnityEngine.Vector3 firstAngle, UnityEngine.Vector3 secondAngle)
    {
        System.Random rnd = new System.Random();

        float x;
        float y;
        float z;

        x = (float)rnd.NextDouble() * (firstAngle.x - secondAngle.x) + secondAngle.x;
        y = (float)rnd.NextDouble() * (firstAngle.y - secondAngle.y) + secondAngle.y;
        z = (float)rnd.NextDouble() * (firstAngle.z - secondAngle.z) + secondAngle.z;
        return new UnityEngine.Vector3(x, y, z);
    }
    public void SpawnParticle(UnityEngine.Vector3 position, UnityEngine.Vector3 thrust, int type, GameObject prefub)
    {
        particles.Add(Instantiate(prefub, position, UnityEngine.Quaternion.identity)); 

        //particles.Add(new ParticleBase(temp, thrust, type));
        //particles.Add(temp);
        
    }
}
