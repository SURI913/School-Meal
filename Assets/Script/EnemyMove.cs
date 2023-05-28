using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float distance;
    public float atkDistance;
    public LayerMask isLayer;
    public float speed;

    public GameObject bullet; //�Ѿ�
    public GameObject pos; //�Ѿ� ������ġ

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
            if (Vector2.Distance(transform.position, raycast.collider.transform.position) < atkDistance) //�������� �� �̸� ����
            {
                if (currenttime <= 0)
                {
                    GameObject bulletcopy = Instantiate(bullet, transform.position, transform.rotation);
                    currenttime = cooltime;
                }
            }
            else //�ƴϸ� �ٰ�����
            {
                transform.position = Vector3.MoveTowards(transform.position, raycast.collider.transform.position, Time.deltaTime * speed);
            }
            currenttime -= Time.deltaTime;
        }
    }
}
