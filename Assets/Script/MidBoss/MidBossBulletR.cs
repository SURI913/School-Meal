using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBossBulletR : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    void Start()
    {
        Invoke("DestroyBullet", 3);
    }

    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider != null)
        {
            DestroyBullet();
        }
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
