using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyProjectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �߻�ü�� �ε��� ������Ʈ�� �±װ� "Player"�̸�
        if (collision.CompareTag("Player"))
        {
            // �ε��� ������Ʈ ü�� ����(�÷��̾�)
            //collision.GetComponent<PlayerHp>().TakeDamage(damage);
            // �� ������Ʈ ����(�߻�ü)
            Destroy(gameObject);
        }
    }
}
