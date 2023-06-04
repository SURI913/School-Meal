using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBossMove : MonoBehaviour
{
    public float distance;  //플레이어의 위치를 감지하는 범위
    public float atkDistance;   //공격 거리
    public LayerMask isLayer;   //레이캐스트를 쓰기 위한 변수
    public float speed; //캐릭터 움직임 스피드

    public int atkrand; //공격 랜덤으로 지정하는 변수

    //책 떨어지는 공격 랜덤 포지션 변수
    public double posrand1;
    public double posrand2;
    public double posrand3;

    //총알 오브젝트 생성(프리펩)
    public GameObject bulletL;
    public GameObject bulletR;
    public GameObject bulletU;

    //떨어지는 공격총알 생성(스피드와 크기 다름)
    public GameObject bulletD1; //사이즈 작고 속도 빠름
    public GameObject bulletD2; //중간 사이즈 중간 속도
    public GameObject bulletD3; //사이즈 크고 속도 느림

    //잡몸 소환용
    public GameObject enemy;

    private Vector3 pos; // 중간보스 중심 공격좌표

    //떨어지는 랜덤 좌표(위치 프리펩 x MidBoss 스테이지 만들 때 따로 추가하는걸로)
    [SerializeField]
    private Transform pos2; // 공격이떨어지는 랜덤 좌표1
    [SerializeField]
    private Transform pos3;
    [SerializeField]
    private Transform pos4;


    //애니메이션을 위한 변수
    private Animator animator;
    private bool isRun;
    private int turn = 1;

    private float ScaleVal_X;   //스케일 값은 float로 되어있음
    private float ScaleVal_Y;

    new Rigidbody2D rigidbody;

    void Start()
    {
        animator = GetComponent<Animator>();
        ScaleVal_X = transform.localScale.x;
        ScaleVal_Y = transform.localScale.y;
        //위치 초기값설정
        pos2.transform.position = new Vector3(-17f, 4.5f, -1);
        pos3.transform.position = new Vector3(-17f, 4.5f, -1);
        pos4.transform.position = new Vector3(-17f, 4.5f, -1);

        pos = this.GetComponent<Transform>().position;
    }
    public float cooltime; //공격 쿨타임
    public float currenttime;
    public float atktime1;
    public float atktime2;
    public float atktime3;

    void Update()
    {
        atktime1 += Time.deltaTime;
        atktime2 += Time.deltaTime;
        atktime3 += Time.deltaTime;

        pos = this.GetComponent<Transform>().position;

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
                        GameObject bulletcopy1 = Instantiate(bulletR, pos, transform.rotation);
                        GameObject bulletcopy2 = Instantiate(bulletL, pos, transform.rotation);
                        GameObject bulletcopy3 = Instantiate(bulletU, pos, transform.rotation);
                    }
                    else
                    {
                        GameObject bulletcopy4 = Instantiate(enemy, pos, transform.rotation);
                        GameObject bulletcopy5 = Instantiate(enemy, pos, transform.rotation);
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
                        GameObject bulletcopy1 = Instantiate(bulletR, pos, transform.rotation);
                        GameObject bulletcopy2 = Instantiate(bulletL, pos, transform.rotation);
                        GameObject bulletcopy3 = Instantiate(bulletU, pos, transform.rotation);
                    }
                    else
                    {
                        GameObject bulletcopy4 = Instantiate(enemy, pos, transform.rotation);
                        GameObject bulletcopy5 = Instantiate(enemy, pos, transform.rotation);
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
}
