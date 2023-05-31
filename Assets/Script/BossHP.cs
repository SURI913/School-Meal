using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    [SerializeField]
    public double maxHP = 500;
    public double currentHP;
    private SpriteRenderer spriteRenderer;
    private Boss boss;
    private GameObject player_attack;
    private AudioSource hit;

    //데미지 애니메이션
    private Animator animator;

    private void Start()
    {
        maxHP = GameManager.instance.GetMaxBossHP();
        currentHP = GameManager.instance.GetBossHP();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boss = GetComponent<Boss>();

        animator = GetComponent<Animator>(); //애니메이션
    }

    public void TakeDamage(float damage)
    {
        //데미지를 입은 경우 최근체력 감소시킴
        animator.SetBool("isHunted", true);
        currentHP -= damage;
        GameManager.instance.setBossHP(currentHP);
        GameManager.instance.PlayEnemyHitSound();
        GameManager.instance.setWhoseDamage(3);
        if(currentHP <= 0)
        {
            // ü���� 0dlaus OnDie() �Լ��� ȣ���ؼ� �׾����� ó���� �Ѵ�.
            boss.Ondie();
        }
        animator.SetBool("isHunted", false);
    }
}
