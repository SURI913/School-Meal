using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;                      // �� ���ݷ�
    [SerializeField]
    private int scorePoint = 100;             // �� óġ�� ȹ�� ����
    private PlayerController playerController;  // �÷��̾� ����(Score) ������ �����ϱ� ����

    private void Awake()
    {
        // ������Ʈ Ǯ���� �̿��� ������Ʈ�� ������ ��쿡�� ���� 1���� Find�� �̿��Ͽ�
        // PlayerController�� ������ �����صΰ� ����ϴ� ���� ���꿡 ȿ������
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �ε��� ������Ʈ�� �±װ� "Player"�̸�
        if (collision.CompareTag("Player"))
        {
            // �� ���ݷ¸�ŭ �÷��̾� ü�� ����
            collision.GetComponent<PlayerHp>().TakeDamage(damage);
            // �� ���
            OnDie();
        }
    }

    public void OnDie()
    {
        // �÷��̾��� ������ scorePoint��ŭ ������Ų��.
        //playerController.Score += scorePoint;
        // �� ������Ʈ ����
        Destroy(gameObject);
    }
}
