using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;                      // 적 공격력
    [SerializeField]
    private int scorePoint = 100;             // 적 처치시 획득 점수
    private PlayerController playerController;  // 플레이어 점수(Score) 정보에 접근하기 위해

    private void Awake()
    {
        // 오브젝트 풀링을 이용해 오브젝트를 재사용할 경우에는 최초 1번만 Find를 이용하여
        // PlayerController의 정보를 저장해두고 사용하는 것이 연산에 효율적임
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에게 부딪힌 오브젝트의 태그가 "Player"이면
        if (collision.CompareTag("Player"))
        {
            // 적 공격력만큼 플레이어 체력 감소
            collision.GetComponent<PlayerHp>().TakeDamage(damage);
            // 적 사망
            OnDie();
        }
    }

    public void OnDie()
    {
        // 플레이어의 점수를 scorePoint만큼 증가시킨다.
        playerController.Score += scorePoint;
        // 적 오브젝트 삭제
        Destroy(gameObject);
    }
}
