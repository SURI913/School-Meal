using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBossBulletR : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    // Start is called before the first frame update
    private Animator animator; //애니메이션 추가
    void Start()
    {
        Invoke("DestroyBullet", 3);
        animator = GetComponent<Animator>(); //애니메이션
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isHunted" , true); //회전
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider != null)
        {
            if (ray.collider.tag == "player")
            {
                animator.SetBool("isHunted" , false); //맞으면 오브젝트 회전 멈춤

            }
            DestroyBullet();
        }
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
