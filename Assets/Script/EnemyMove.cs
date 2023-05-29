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

    //애니메이션을 위한 변수
    private Animator animator;
    private bool isRun;
    private int turn = 1;

    private float ScaleVal_X;   //스케일 값은 float로 되어있음
    private float ScaleVal_Y;

    void Start()
    {
        animator = GetComponent<Animator>();
        ScaleVal_X = transform.localScale.x;
        ScaleVal_Y = transform.localScale.y;
    }
    public float cooltime;
    public float currenttime;

    void Update()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if (raycast.collider != null)
        {
            isRun = true;
            if (Vector2.Distance(transform.position, raycast.collider.transform.position) < atkDistance) //�������� �� �̸� ����
            {
                isRun = false;
                if (currenttime <= 0)
                {
                    GameObject bulletcopy = Instantiate(bullet, transform.position, transform.rotation);
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
        animator.SetBool("isRun", isRun);
        transform.localScale = new Vector3(ScaleVal_X*turn, ScaleVal_Y, 1);
    }
}
