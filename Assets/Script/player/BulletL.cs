using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletL: MonoBehaviour
{
    public float speed; //총알 날라가는 속도
    public float distance;
    public LayerMask isLayer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider != null)
        {
            DestroyBullet(); //오브젝트에 총알이 닿으면 삭제
        }
        transform.Translate(transform.right * -1 * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}