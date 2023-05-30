using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private double maxHP = 10;  // �ִ� ü��
    private double currentHP;  // ���� ü��
    private SpriteRenderer spriteRenderer;

    public double MaxHP => maxHP;               // maxHP ������ ������ �� �ִ� ������Ƽ (Get�� ����)
    public double CurrentHP => currentHP;      // currentHP ������ ������ �� �ִ� ������Ƽ (Get�� ����)

    private void Start()
    {
        currentHP = GameManager.instance.GetCurrnetHP();
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        // ���� ü���� damage��ŭ ����
        currentHP -= damage;

        // ü���� 0���� = �÷��̾� ĳ���� ���
        if(currentHP <= 0) 
        {
            Debug.Log("Player HP : 0.. Die");
            Destroy(gameObject);
        }
    }
}
