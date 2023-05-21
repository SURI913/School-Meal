using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //주석 깨진거 수정해주세요
    public double Hp; //����ü��
    public double MaxHp; //�ִ�ü��
    public double enemyHP;
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
        if (Hp > MaxHp) //�ִ�ü��
        {
            Hp = MaxHp;
        }
        if (Hp <= 0) // ���
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

    // 함수 이름 수정 필요
    public void r()
    {
        Hp = Hp + 1;
    }

    public void l()
    {
        Hp = Hp - 1;
    }

    // Update is called once per frame
    void Update()
    {
        HpSystem();
        enemyHpSystem();
    }

}
