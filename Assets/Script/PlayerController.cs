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
        // Score 값이 음수가 되지않도록
        set => score = Mathf.Max(0, value);
        get => score;
    }

    //애니메이션을 위한 변수
    private Animator animator;
    private bool isRun;
    private int turn = 1;
    private float ScaleVal_X;   //스케일 값은 float로 되어있음
    private float ScaleVal_Y;

    private void Start()
    {
        //애니메이터 변수 초기화
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
        //방향 키를 눌러 이동 방향 설정
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        isRun = false;
        if (Input.GetKey("right"))
        {
            //회전 및 애니메이션 키  설정
            isRun = true;
            turn = -1;
        }
        if (Input.GetKey("left"))
        {
            //회전 및 애니메이션 키  설정
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

        //공격 키를 Down/Up으로 공격 시작/종료
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
        // 바깥으로 못나가게 함
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
            Mathf.Clamp(transform.position.y,stageData.LimitMin.y, stageData.LimitMax.y));
    }
}
