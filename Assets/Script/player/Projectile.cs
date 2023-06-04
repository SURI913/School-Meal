using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 총알이 보스를 공격하면 보스 체력을 깎는다
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHP>().TakeDamage(damage);
        }
        // 총알이 미들보스를 공격하면 보스 체력을 깎는다
        if (collision.CompareTag("MidBoss"))
        {
            collision.GetComponent<MidBossHp>().TakeDamage(damage);
        }
        // 총알이 적보스를 공격하면 보스 체력을 깎는다
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHp>().TakeDamage(damage);
        }
    }
}
