using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float distance;
    public float atkDistance;
    public LayerMask isLayer;
    public float speed;

    public int atkrand;
    public double posrand1;
    public double posrand2;
    public double posrand3;

    public GameObject bulletL;
    public GameObject bulletR;
    public GameObject bulletU;
    public GameObject bulletD1;
    public GameObject bulletD2;
    public GameObject bulletD3;
    public GameObject enemy;
    public Transform pos1; // 중간보스 중심 공격좌표

    public Transform pos2; // 공격이떨어지는 랜덤 좌표1
    public Transform pos3;
    public Transform pos4;


    //애니메이션을 위한 변수
    private Animator animator;
    private bool isRun;
    private int turn = 1;

    private float ScaleVal_X;   //스케일 값은 float로 되어있음
    private float ScaleVal_Y;

    private float jumpPower = 7.0f;
    new Rigidbody2D rigidbody;
    private PlayerController player;

    void Start()
    {
        animator = GetComponent<Animator>();
        ScaleVal_X = transform.localScale.x;
        ScaleVal_Y = transform.localScale.y;
        pos2.transform.position = new Vector3(-17f, 4.5f, -1);
        pos3.transform.position = new Vector3(-17f, 4.5f, -1);
        pos4.transform.position = new Vector3(-17f, 4.5f, -1);
    }
    public float cooltime;
    public float currenttime;
    public float atktime1;
    public float atktime2;
    public float atktime3;

    void Update()
    {
        atktime1 += Time.deltaTime;
        atktime2 += Time.deltaTime;
        atktime3 += Time.deltaTime;

        pos2.transform.Translate(new Vector3(0.02f, 0, 0));
        pos3.transform.Translate(new Vector3(0.05f, 0, 0));
        pos4.transform.Translate(new Vector3(0.1f, 0, 0));
        if (pos2.transform.position.x >= 31)
        {
            pos2.transform.position = new Vector3(-17f, 4.5f, -1);
        }
        if (pos3.transform.position.x >= 31)
        {
            pos3.transform.position = new Vector3(-17f, 4.5f, -1);
        }
        if (pos4.transform.position.x >= 31)
        {
            pos4.transform.position = new Vector3(-17f, 4.5f, -1);
        }

        if (atktime1 >= 2)
        {
            GameObject bulletcopy1 = Instantiate(bulletD1, pos2.position, transform.rotation);
            GameObject bulletcopy2 = Instantiate(bulletD2, pos3.position, transform.rotation);
            atktime1 = 0;
        }
        if (atktime2 >= 7)
        {
            GameObject bulletcopy1 = Instantiate(bulletD3, pos2.position, transform.rotation);
            GameObject bulletcopy3 = Instantiate(bulletD1, pos4.position, transform.rotation);
            atktime2 = 0;
        }
        if (atktime3 >= 11)
        {
            GameObject bulletcopy1 = Instantiate(bulletD2, pos2.position, transform.rotation);
            GameObject bulletcopy2 = Instantiate(bulletD3, pos3.position, transform.rotation);
            GameObject bulletcopy3 = Instantiate(bulletD1, pos4.position, transform.rotation);
            atktime3 = 0;
        }



        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if (raycast.collider != null)
        {
            isRun = true;
            if (Vector2.Distance(transform.position, raycast.collider.transform.position) < atkDistance) //�������� �� �̸� ����
            {
                isRun = false;
                if (currenttime <= 0)
                {
                    atkrand = Random.Range(0, 10); // 0~9 까지 랜덤 숫자
                    if (atkrand >= 1)
                    {
                        GameObject bulletcopy1 = Instantiate(bulletR, pos1.position, transform.rotation);
                        GameObject bulletcopy2 = Instantiate(bulletL, pos1.position, transform.rotation);
                        GameObject bulletcopy3 = Instantiate(bulletU, pos1.position, transform.rotation);
                    }
                    else
                    {
                        GameObject bulletcopy4 = Instantiate(enemy, pos1.position, transform.rotation);
                        GameObject bulletcopy5 = Instantiate(enemy, pos1.position, transform.rotation);
                    }
                    currenttime = cooltime;
                }
            }
            else //�ƴϸ� �ٰ����� 주석깨진거 수정해주세요!
            {
                isRun = true;
                transform.position = Vector3.MoveTowards(transform.position, raycast.collider.transform.position, Time.deltaTime * speed);
            }
            currenttime -= Time.deltaTime;
        }

        //오른쪽 움직임

        RaycastHit2D raycast1 = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (raycast1.collider != null)
        {
            isRun = true;
            turn = -1;
            if (Vector2.Distance(transform.position, raycast1.collider.transform.position) < atkDistance) //�������� �� �̸� ����
            {
                isRun = false;
                if (currenttime <= 0)
                {
                    atkrand = Random.Range(0, 10); // 0~9 까지 랜덤 숫자
                    if (atkrand >= 3)
                    {
                        GameObject bulletcopy1 = Instantiate(bulletR, pos1.position, transform.rotation);
                        GameObject bulletcopy2 = Instantiate(bulletL, pos1.position, transform.rotation);
                        GameObject bulletcopy3 = Instantiate(bulletU, pos1.position, transform.rotation);
                    }
                    else
                    {
                        GameObject bulletcopy4 = Instantiate(enemy, pos1.position, transform.rotation);
                        GameObject bulletcopy5 = Instantiate(enemy, pos1.position, transform.rotation);
                    }
                    currenttime = cooltime;
                }
            }
            else //�ƴϸ� �ٰ����� 주석깨진거 수정해주세요!
            {
                isRun = true;
                transform.position = Vector3.MoveTowards(transform.position, raycast1.collider.transform.position, Time.deltaTime * speed);
            }
            currenttime -= Time.deltaTime;
        }

        animator.SetBool("isRun", isRun);
        transform.localScale = new Vector3(ScaleVal_X*turn, ScaleVal_Y, 1);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.name=="SGround")
    //    {
    //        rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    //    }
    //}

}
