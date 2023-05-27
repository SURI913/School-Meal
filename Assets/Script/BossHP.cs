using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10;
    private float currentHP;
    private SpriteRenderer spriteRenderer;
    private Boss boss;

    private void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boss = GetComponent<Boss>();
    }

    public void TakeDamage(float damage)
    {
        // ���� ü���� damage��ŭ ����
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // ü���� 0���� = �÷��̾� ĳ���� ���
        if(currentHP <= 0)
        {
            // ü���� 0dlaus OnDie() �Լ��� ȣ���ؼ� �׾����� ó���� �Ѵ�.
            boss.Ondie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        // �÷��̾��� ������ ����������
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        // �÷��̾��� ������ ���� ������ �Ͼ������
        // (���� ������ �Ͼ���� �ƴ� ��� ���� ���� ���� ����)
        spriteRenderer.color = Color.white;
    }
}
