using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public GameObject rightattack;
    public GameObject leftattack;
    public GameObject upattack;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public float cooltime;
    public float curtime;

    void Start()
    {
        
    }
    void Update()
    {
        curtime -= Time.deltaTime;

        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.D)) //오른쪽 공격
            {
                Instantiate(rightattack, pos1.position, transform.rotation);
            }
            else if (Input.GetKey(KeyCode.A)) //왼쪽 공격
            {
                Instantiate(leftattack, pos2.position, transform.rotation);
            }
            else if (Input.GetKey(KeyCode.W)) //윗쪽 공격
            {
                Instantiate(upattack, pos3.position, transform.rotation);
            }
            curtime = cooltime;
        }
    }
}
