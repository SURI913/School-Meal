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

    private void Start()
    {
        currentHP = maxHP;
        currentHP = GameManager.instance.GetBossHP();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boss = GetComponent<Boss>();
    }

    public void TakeDamage(float damage)
    {
        // ���� ü���� damage��ŭ ����
        currentHP -= damage;
        GameManager.instance.setBossHP(currentHP);
        // ü���� 0���� = �÷��̾� ĳ���� ���
        if(currentHP <= 0)
        {
            // ü���� 0dlaus OnDie() �Լ��� ȣ���ؼ� �׾����� ó���� �Ѵ�.
            boss.Ondie();
        }
    }
}
