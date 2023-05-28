using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float distance;
    public float atkDistance;
    public LayerMask isLayer;
    public float speed;

    public GameObject bullet; //총알
    public GameObject pos; //총알 생성위치

    void Start()
    {

    }
    public float cooltime;
    public float currenttime;

    void Update()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if (raycast.collider != null)
        {
            if (Vector2.Distance(transform.position, raycast.collider.transform.position) < atkDistance) //일정범위 안 이면 공격
            {
                if (currenttime <= 0)
                {
                    GameObject bulletcopy = Instantiate(bullet, transform.position, transform.rotation);
                    currenttime = cooltime;
                }
            }
            else //아니면 다가가기
            {
                transform.position = Vector3.MoveTowards(transform.position, raycast.collider.transform.position, Time.deltaTime * speed);
            }
            currenttime -= Time.deltaTime;
        }
    }
}
