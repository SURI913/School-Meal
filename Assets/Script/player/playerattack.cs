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

    public	bool IsAttacked		{ set; get; } = false; //플레이어 공격이 가능하도록 설정하는용도

    void Start()
    {
        pos = this.GetComponent<Transform>().position; //플레이어 위치 가져옴

        if(GameManager.instance.StageNumberTag != "Tutorial"){
            //스테이지가 본격적으로 시작하면 공격 자유롭게 가능
            IsAttacked = true;
        }
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
        curtime -= Time.deltaTime;
        pos = this.GetComponent<Transform>().position; //플레이어 위치 가져옴

        if (curtime <= 0 && IsAttacked == true)
        {
            if (atktype == 0) //기본총알
            {
                if (Input.GetKey(KeyCode.A)) //왼쪽으로 공격
                {
                    Instantiate(basicleftattack, pos, transform.rotation);
                }
                else if (Input.GetKey(KeyCode.D))   //오른쪽으로 공격
                {
                    Instantiate(basicrightattack, pos, transform.rotation);
                }
                else if (Input.GetKey(KeyCode.W))   //위로 공격
                {
                    Instantiate(basicupattack, pos, transform.rotation);
                }
                curtime = cooltime;
            }
            if (atktype == 1) //관통총알
            {
                if (Input.GetKey(KeyCode.A)) //왼쪽으로 공격
                {
                    Instantiate(Penetrationleftattack, pos, transform.rotation);
                }
                else if (Input.GetKey(KeyCode.D))   //오른쪽으로 공격
                {
                    Instantiate(Penetrationrightattack, pos, transform.rotation);
                }
                else if (Input.GetKey(KeyCode.W))   //위로 공격
                {
                    Instantiate(Penetrationupattack, pos, transform.rotation);
                }
                curtime = cooltime;
            }
            if (atktype == 2) //속사총알
            {
                if (Input.GetKey(KeyCode.A)) //왼쪽으로 공격
                {
                    quickfireL();
                    Invoke("quickfireL", 0.15f);
                    Invoke("quickfireL", 0.3f);
                }
                else if (Input.GetKey(KeyCode.D))   //오른쪽으로 공격
                {
                    quickfireR();
                    Invoke("quickfireR", 0.15f);
                    Invoke("quickfireR", 0.3f);
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
