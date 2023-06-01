using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletR: MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    // Start is called before the first frame update
    //private Animator animator; //애니메이션 등록
    void Start()
    {
        Invoke("DestroyBullet", 2);
        //animator = GetComponent<Animator>();
        //animator.SetBool("isHunted", true);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider != null)
        {
            if (ray.collider.tag == "MidBoss")
            {
                //animator.SetBool("isHunted", false);
                //GameManager.enemyHP = GameManager.enemyHP - 1; //적 체력 스크립트 따로 추가해서 관리할거 (player꺼)
                //GameManager.instance.GetisHitMidBoss(); //사운드 통일되었으니 palyer 제외 아무거나 가져오기
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