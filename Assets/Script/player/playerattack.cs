using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public GameObject rightattack;
    public GameObject leftattack;
    public GameObject upattack;
    public Vector3 pos;
    public float cooltime;
    public float curtime;

    void Start()
    {
        pos = this.GetComponent<Transform>().position; //플레이어 위치 가져옴
    }
    void Update()
    {
        //무기변경
        if(GameManager.instance.Changeweapon1 == true || GameManager.instance.Changeweapon1 == true){
            leftattack = GameManager.instance.GetWeaposnL();
            rightattack = GameManager.instance.GetWeaposnR();
            upattack = GameManager.instance.GetWeaposnU();
        }
        curtime -= Time.deltaTime;
        pos = this.GetComponent<Transform>().position; //플레이어 위치 가져옴

        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.D)) //오른쪽으로 공격
            {
                Instantiate(rightattack, pos, transform.rotation);
            }
            else if (Input.GetKey(KeyCode.A))   //왼쪽으로 공격
            {
                Instantiate(leftattack, pos, transform.rotation);
            }
            else if (Input.GetKey(KeyCode.W))   //위로 공격
            {
                Instantiate(upattack, pos, transform.rotation);
            }
            curtime = cooltime;
        }
    }
}
