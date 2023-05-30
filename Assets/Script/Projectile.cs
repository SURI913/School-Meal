using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �߻�ü�� �΋H�� ������Ʈ�� �±װ� "Boss"�̸�
        if (collision.CompareTag("Boss"))
        {
            // �ε��� ������Ʈ ���ó��(��)
            collision.GetComponent<BossHP>().TakeDamage(damage);
            // �� ������Ʈ ����(�߻�ü)
            Destroy(gameObject);
        }
    }
}
