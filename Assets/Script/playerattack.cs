using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public GameObject fireballR;
    public GameObject fireballL;
    public GameObject fireballU;
    public GameObject fireballD;
    public static double attack = 0;
    public Transform pos;
    public float cooltime;
    public float curtime;

    void Start()
    {
        
    }
    void Update()
    {
        if(curtime >= 0)
        {
            if (Input.GetKey(KeyCode.B))
            {
                if (attack == 0) //������
                {
                    Instantiate(fireballR, pos.position, transform.rotation);
                }
                if (attack == 1) //����
                {
                    Instantiate(fireballL, pos.position, transform.rotation);
                }
                if (attack == 2) //��
                {
                    Instantiate(fireballU, pos.position, transform.rotation);
                }
                if (attack == 3) //�Ʒ�
                {
                    Instantiate(fireballD, pos.position, transform.rotation);
                }
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
}
