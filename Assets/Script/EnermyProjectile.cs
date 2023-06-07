using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyProjectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHp>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
