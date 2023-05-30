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
        // 현재 체력을 damage만큼 감소
        currentHP -= damage;
        GameManager.instance.setBossHP(currentHP);
        // 체력이 0이하 = 플레이어 캐릭터 사망
        if(currentHP <= 0)
        {
            // 체력이 0dlaus OnDie() 함수를 호출해서 죽었을때 처리를 한다.
            boss.Ondie();
        }
    }
}
