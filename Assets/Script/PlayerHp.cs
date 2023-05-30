using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private double maxHP = 10;  // 최대 체력
    private double currentHP;  // 현재 체력
    private SpriteRenderer spriteRenderer;

    public double MaxHP => maxHP;               // maxHP 변수에 접근할 수 있는 프로퍼티 (Get만 가능)
    public double CurrentHP => currentHP;      // currentHP 변수에 접근할 수 있는 프로퍼티 (Get만 가능)

    private void Start()
    {
        currentHP = GameManager.instance.GetCurrnetHP();
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        // 현재 체력을 damage만큼 감소
        currentHP -= damage;

        // 체력이 0이하 = 플레이어 캐릭터 사망
        if(currentHP <= 0) 
        {
            Debug.Log("Player HP : 0.. Die");
            Destroy(gameObject);
        }
    }
}
