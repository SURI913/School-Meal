using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Meteor : MonoBehaviour
{
    public GameObject meteorA;
    public GameObject meteorB;
    public GameObject meteorC;
    public GameObject meteorD;
    public GameObject layerA;
    public GameObject layerB;
    public GameObject layerC;

    private Vector3 meteor1;
    private Vector3 meteor2;
    private Vector3 meteor3;
    private Vector3 meteor4;
    private Vector3 layer1;   // 레이저 오타남 ㅎ
    private Vector3 layer2;
    private Vector3 layer3;

    private float atktime1 = 0;
    private float atktime2 = 0;
    private float atktime3 = 0;
    private float atktime4 = 0;

    // Start is called before the first frame update
    void Start()
    {
        meteor1 = new Vector3(-17f, 4.5f, -1);
        meteor2 = new Vector3(-17f, 4.5f, -1);
        meteor3 = new Vector3(-17f, 4.5f, -1);
        meteor4 = new Vector3(-17f, 4.5f, -1);
        layer1 = new Vector3(-17f, 0, -1);
        layer2 = new Vector3(-17f, 0, -1);
        layer3 = new Vector3(-17f, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        atktime1 += Time.deltaTime;
        atktime2 += Time.deltaTime;
        atktime3 += Time.deltaTime;
        atktime4 += Time.deltaTime;

        meteor1 += new Vector3(0.3f, 0, 0);
        meteor2 += new Vector3(0.7f, 0, 0);
        meteor3 += new Vector3(2f, 0, 0);
        meteor4 += new Vector3(3f, 0, 0);
        layer1 += new Vector3(0.4f, 0, 0);
        layer2 += new Vector3(0.9f, 0, 0);
        layer3 += new Vector3(1.2f, 0, 0);


        if (meteor1.x >= 33)
            meteor1 = new Vector3(-17f, 4.5f, -1);
        if(meteor2.x >= 33)
            meteor2 = new Vector3(-17f, 4.5f, -1);
        if (meteor3.x >= 33)
            meteor3 = new Vector3(-17f, 4.5f, -1);
        if (meteor4.x >= 33)
            meteor4 = new Vector3(-17f, 4.5f, -1);
        if(layer1.x >= 33)
            layer1 = new Vector3(-17f, 0, -1);
        if (layer2.x >= 33)
            layer2 = new Vector3(-17f, 0, -1);
        if (layer3.x >= 33)
            layer3 = new Vector3(-17f, 0, -1);


        if (atktime1 >= 3)
        {
            GameObject bulletcopy1 = Instantiate(meteorA, meteor1, transform.rotation);
            GameObject bulletcopy2 = Instantiate(meteorB, meteor2, transform.rotation);
            GameObject layercopy1 = Instantiate(layerA, layer1, Quaternion.identity);
            GameObject layercopy2 = Instantiate(layerB, layer2, Quaternion.identity);
            atktime1 = 0;
        }
        if (atktime2 >= 7)
        {
            GameObject bulletcopy1 = Instantiate(meteorA, meteor1, transform.rotation);
            GameObject bulletcopy2 = Instantiate(meteorB, meteor3, transform.rotation);
            GameObject layercopy1 = Instantiate(layerA, layer1, Quaternion.identity);
            atktime2 = 0;
        }
        if (atktime3 >= 11)
        {
            GameObject bulletcopy1 = Instantiate(meteorC, meteor2, transform.rotation);
            GameObject bulletcopy2 = Instantiate(meteorC, meteor3, transform.rotation);
            GameObject layercopy2 = Instantiate(layerB, layer2, Quaternion.identity);
            atktime3 = 0;
        }
        if (atktime4 >= 16)
        {
            GameObject bulletcopy1 = Instantiate(meteorD, meteor3, transform.rotation);
            GameObject bulletcopy2 = Instantiate(meteorD, meteor4, transform.rotation);
            GameObject layercopy3 = Instantiate(layerC, layer3, Quaternion.identity);
            atktime4 = 0;
        }

    }
}
