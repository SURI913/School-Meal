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

    private Vector3 meteor1;
    private Vector3 meteor2;
    private Vector3 meteor3;
    private Vector3 meteor4;

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

        if(meteor1.x >= 33)
            meteor1 = new Vector3(-17f, 4.5f, -1);
        if(meteor2.x >= 33)
            meteor2 = new Vector3(-17f, 4.5f, -1);
        if (meteor3.x >= 33)
            meteor3 = new Vector3(-17f, 4.5f, -1);
        if (meteor4.x >= 33)
            meteor4 = new Vector3(-17f, 4.5f, -1);

        if (atktime1 >= 3)
        {
            GameObject bulletcopy1 = Instantiate(meteorA, meteor1, transform.rotation);
            GameObject bulletcopy2 = Instantiate(meteorB, meteor2, transform.rotation);
            atktime1 = 0;
        }
        if (atktime2 >= 7)
        {
            GameObject bulletcopy1 = Instantiate(meteorA, meteor1, transform.rotation);
            GameObject bulletcopy2 = Instantiate(meteorB, meteor3, transform.rotation);
            atktime2 = 0;
        }
        if (atktime3 >= 11)
        {
            GameObject bulletcopy1 = Instantiate(meteorC, meteor2, transform.rotation);
            GameObject bulletcopy2 = Instantiate(meteorC, meteor3, transform.rotation);
            atktime3 = 0;
        }
        if (atktime4 >= 16)
        {
            GameObject bulletcopy1 = Instantiate(meteorD, meteor3, transform.rotation);
            GameObject bulletcopy2 = Instantiate(meteorD, meteor4, transform.rotation);
            atktime4 = 0;
        }

    }
}
