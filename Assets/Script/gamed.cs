using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamed : MonoBehaviour
{
    public double Hp = 5; //����ü��
    public double MaxHp = 10; //�ִ�ü��
    public static double enemyHP = 5;
    public GameObject enemy;

    GameObject HPtext1;
    GameObject enemyHPtext;

    void Start()
    {
        this.HPtext1 = GameObject.Find("HPtext1");
        this.enemyHPtext = GameObject.Find("enemyHPtext");
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
        this.HPtext1.GetComponent<Text>().text = "HP." + Hp.ToString();

    }

    public void enemyHpSystem()
    {
        this.enemyHPtext.GetComponent<Text>().text = "HP." + enemyHP.ToString();
        if (enemyHP <= 0)
        {
            Destroy(enemy);
            this.enemyHPtext.GetComponent<Text>().text = "";
        }
    }

    public void r()
    {
        Hp = Hp + 1;
    }

    public void l()
    {
        Hp = Hp - 1;
    }

    void Update()
    {
        HpSystem();
        enemyHpSystem();
    }
}
