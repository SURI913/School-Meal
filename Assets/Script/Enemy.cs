using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;                      //데미지 1
    private PlayerController playerController;  // �÷��̾� ����(Score) ������ �����ϱ� ����

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //공격대상이 플레이어라면
        if (collision.CompareTag("Player"))
        {
            //플레이어의 체력을 깎음
            collision.GetComponent<PlayerHp>().TakeDamage(damage);
            if(collision.GetComponent<PlayerHp>().CurrentHP <=0){
                
            }
            OnDie();
        }
    }

    public void OnDie()
    {
        //체력이 0이라면
        Destroy(gameObject);
    }
}
