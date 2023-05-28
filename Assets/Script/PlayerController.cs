using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;
    private Movement2D movement2D;
    private weapon weapon;

    private int score;
    public int Score
    {
        // Score ���� ������ �����ʵ���
        set => score = Mathf.Max(0, value);
        get => score;
    }

    //�ִϸ��̼��� ���� ����
    private Animator animator;
    private bool isRun;
    private int turn = 1;
    private float ScaleVal_X;   //������ ���� float�� �Ǿ�����
    private float ScaleVal_Y;

    private void Start()
    {
        //�ִϸ����� ���� �ʱ�ȭ
        animator = GetComponent<Animator>();
        ScaleVal_X = transform.localScale.x;
        ScaleVal_Y = transform.localScale.y;
    }

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        weapon = GetComponent<weapon>();
    }


    private void Update()
    {
        //���� Ű�� ���� �̵� ���� ����
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        isRun = false;
        if (Input.GetKey("right"))
        {
            //ȸ�� �� �ִϸ��̼� Ű  ����
            isRun = true;
            turn = -1;
        }
        if (Input.GetKey("left"))
        {
            //ȸ�� �� �ִϸ��̼� Ű  ����
            isRun = true;
            turn = 1;
        }
        if (Input.GetKey("up")|| Input.GetKey("down"))
        {
            isRun = true;
        }
        animator.SetBool("isRun", isRun);
        transform.localScale = new Vector3(ScaleVal_X * turn, ScaleVal_Y, 1);

        movement2D.MoveTo(new Vector3(x, y, 0));

        //���� Ű�� Down/Up���� ���� ����/����
        if(Input.GetKeyDown(keyCodeAttack))
        {
            weapon.StartFiring();
        }
        else if(Input.GetKeyUp(keyCodeAttack)) 
        { 
            weapon.StopFiring();
        }
    }

    private void LateUpdate()
    {
        // �ٱ����� �������� ��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
            Mathf.Clamp(transform.position.y,stageData.LimitMin.y, stageData.LimitMax.y));
    }
}
