using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public GameObject fireballR;
    public GameObject fireballL;
    public GameObject fireballU;
    public GameObject fireballD;
    public Transform pos;
    public float cooltime;
    public float curtime;

    void Start()
    {
        
    }

    void Update()
    {
        if(curtime <= 0)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Instantiate(fireballR, pos.position, transform.rotation);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Instantiate(fireballL, pos.position, transform.rotation);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Instantiate(fireballU, pos.position, transform.rotation);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Instantiate(fireballD, pos.position, transform.rotation);
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
}
