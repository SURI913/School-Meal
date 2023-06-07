using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    // 총알타입 기본 0 관통 1 속사 2
    public static int atktype = 0; 
    //기본 총알
    public GameObject basicrightattack;
    public GameObject basicleftattack;
    public GameObject basicupattack;
    // 관통 총알
    public GameObject Penetrationrightattack;
    public GameObject Penetrationleftattack;
    public GameObject Penetrationupattack;

    // 속사 총알 3발 발사
    public GameObject quickfirerightattack;
    public GameObject quickfireleftattack;
    public GameObject quickfireupattack;

    public Vector3 pos;
    public float cooltime;
    public float curtime;

    void Start()
    {
        pos = this.GetComponent<Transform>().position; //플레이어 위치 가져옴
    }
    // 속사화살을 위해
    public void quickfireR()
    {
        Instantiate(quickfirerightattack, pos, transform.rotation);
    }
    public void quickfireL()
    {
        Instantiate(quickfireleftattack, pos, transform.rotation);
    }
    public void quickfireU()
    {
        Instantiate(quickfireupattack, pos, transform.rotation);
    }

    void Update()
    {
        //무기변경
        // if(GameManager.instance.Changeweapon1 == true || GameManager.instance.Changeweapon1 == true){
        //     leftattack = GameManager.instance.GetWeaposnL();
        //     rightattack = GameManager.instance.GetWeaposnR();
        //     upattack = GameManager.instance.GetWeaposnU();
        // }
        curtime -= Time.deltaTime;
        pos = this.GetComponent<Transform>().position; //플레이어 위치 가져옴

        if (curtime <= 0)
        {
            if (atktype == 0) //기본총알
            {
                if (Input.GetKey(KeyCode.A)) //오른쪽으로 공격
                {
                    Instantiate(basicrightattack, pos, transform.rotation);
                }
                else if (Input.GetKey(KeyCode.D))   //왼쪽으로 공격
                {
                    Instantiate(basicleftattack, pos, transform.rotation);
                }
                else if (Input.GetKey(KeyCode.W))   //위로 공격
                {
                    Instantiate(basicupattack, pos, transform.rotation);
                }
                curtime = cooltime;
            }
            if (atktype == 1) //관통총알
            {
                if (Input.GetKey(KeyCode.A)) //오른쪽으로 공격
                {
                    Instantiate(Penetrationrightattack, pos, transform.rotation);
                }
                else if (Input.GetKey(KeyCode.D))   //왼쪽으로 공격
                {
                    Instantiate(Penetrationleftattack, pos, transform.rotation);
                }
                else if (Input.GetKey(KeyCode.W))   //위로 공격
                {
                    Instantiate(Penetrationupattack, pos, transform.rotation);
                }
                curtime = cooltime;
            }
            if (atktype == 2) //속사총알
            {
                if (Input.GetKey(KeyCode.A)) //오른쪽으로 공격
                {
                    quickfireR();
                    Invoke("quickfireR", 0.15f);
                    Invoke("quickfireR", 0.3f);
                }
                else if (Input.GetKey(KeyCode.D))   //왼쪽으로 공격
                {
                    quickfireL();
                    Invoke("quickfireL", 0.15f);
                    Invoke("quickfireL", 0.3f);
                }
                else if (Input.GetKey(KeyCode.W))   //위로 공격
                {
                    quickfireU();
                    Invoke("quickfireU", 0.15f);
                    Invoke("quickfireU", 0.3f);
                }
                curtime = cooltime;
            }
        }
    }
}
