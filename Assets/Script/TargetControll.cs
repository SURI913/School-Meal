using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class TargetControll : MonoBehaviour
{
    float moveX, moveY;
    [SerializeField][Range(3f, 10f)] float moveSpeed = 5f;

    //애니메이션을 위한 변수
    private Animator animator;
    private bool isRun;
    private int turn = 1;
    private float jumpPower = 6.0f; //점프 높이
    private int jumpCount = 0;
    new Rigidbody2D rigidbody;

    private float ScaleVal_X;   //스케일 값은 float로 되어있음
    private float ScaleVal_Y;

    private void Start(){
        //애니메이터 변수 초기화
        animator = GetComponent<Animator>();
        ScaleVal_X = transform.localScale.x;
        ScaleVal_Y = transform.localScale.y;

        rigidbody = GetComponent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    private void Update()
    {

        //방향키로 움직임 설정
        isRun = false;
        moveX = 0;
        moveY = 0;
        if (Input.GetKey("right"))
        {
            moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

            //회전 및 애니메이션 키  설정
            isRun = true;
            turn = -1;
        }
        if(Input.GetKey("left"))
        {
            moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            
            //회전 및 애니메이션 키  설정
            isRun = true;
            turn = 1;
        }
        //점프 코드 
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 0)
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCount = 1;
        }
        
        transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
        animator.SetBool("isRun", isRun);
        transform.localScale = new Vector3(ScaleVal_X*turn, ScaleVal_Y, 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground"&& collision.gameObject.name == "SGround")
        {
            jumpCount = 0;
            //Ground 라는 오브젝트에 닿으면 점프 카운트를 0으로 바꾼다.
        }
    }
    private void LateUpdate()
    {
        // 바깥으로 못나가게 함
        //값 수정 필요
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -16.5f, 31.5f),
            Mathf.Clamp(transform.position.y, -6f, 6f));
    }


}
