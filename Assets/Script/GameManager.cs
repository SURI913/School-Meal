using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //주석 깨진거 수정해주세요
    public double Hp; //현재체력
    public double MaxHp; //최대체력
    public static double enemyHP = 5;
    public GameObject enemy;

    GameObject HPtext;
    GameObject enemyHPtext;
    
    void Start()
    {
        this.HPtext = GameObject.Find("PlayerHPtext");
        this.enemyHPtext = GameObject.Find("EnemyHPtext");
    }

    public void HpSystem()
    {
        if (Hp > MaxHp) //체력이 최대체력을 넘어가지 못하게하기
        {
            Hp = MaxHp;
        }
        if (Hp <= 0) // 플레이어 체력이 0이되면 사망
        {

        }
        this.HPtext.GetComponent<Text>().text = "HP." + Hp.ToString();

    }

    public void enemyHpSystem()
    {
        //텍스트 적 캐릭터 위에 생성되도록 수정

        this.enemyHPtext.GetComponent<Text>().text = "HP." + enemyHP.ToString();
        if (enemyHP <= 0)
        {
            Destroy(enemy);
            this.enemyHPtext.GetComponent<Text>().text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        HpSystem();
        enemyHpSystem();
    }

}
