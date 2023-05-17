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

    private void Start(){
        //애니메이터 변수 초기화
        animator = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    private void Update()
    {

        //if문 변경 필요 + 스케일 *(-1)로 반대방향 전환필요
        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
    }
}
