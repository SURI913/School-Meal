using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBossHp : MonoBehaviour
{
    //체력은 전부 GameMnager에서 가져오고 변경한다.
    private double maxHP;  
    private double currentHP;
    private SpriteRenderer spriteRenderer;

    public double MaxHP => maxHP;               // maxHP ������ ������ �� �ִ� ������Ƽ (Get�� ����)
    public double CurrentHP => currentHP;      // currentHP ������ ������ �� �ִ� ������Ƽ (Get�� ����)

    //데미지 애니메이션
    private Animator animator;


    private void Start()
    {
        //게임매니저에 있는 전체체력을 가져온다.
        currentHP = GameManager.instance.GetMidBossHP();
        maxHP = GameManager.instance.GetMaxMidBossHP();
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>(); //애니메이션
    }

    public void TakeDamage(float damage)
    {
        //데미지를 입은 경우 최근체력 감소시킴
        animator.SetBool("isHunted", true);
        currentHP -= damage;
        GameManager.instance.setMidBossHP(currentHP);   //적 체력값 전달
        GameManager.instance.PlayEnemyHitSound();
        GameManager.instance.setWhoseDamage(2); //중간보스가 데미지를 입었다.

        //체력이 0이면 플레이어 죽음
        if(currentHP <= 0) 
        {
            Debug.Log("MidBoss HP : 0.. Die");
            Destroy(gameObject);
        }
        animator.SetBool("isHunted", false);
    }
}
