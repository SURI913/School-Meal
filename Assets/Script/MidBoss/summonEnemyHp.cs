using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonEnemyHp : MonoBehaviour
{
    //체력은 전부 GameMnager에서 가져오고 변경한다.
    private double maxHP;
    public static double currentHP;
    private SpriteRenderer spriteRenderer;

    public double MaxHP => maxHP;               // maxHP 다른 함수에서 얘를 부를 수 있게
    public double CurrentHP => currentHP;      // currentHP ������ ������ �� �ִ� ������Ƽ (Get�� ����)
    //이거 가져오는게 실시간으로 모든 값 가져오는게 아니라 초기값만 가져오는지 체크

    //데미지 애니메이션
    private Animator animator;


    private void Start()
    {
        //게임매니저에 있는 전체체력을 가져온다.
        currentHP = 50;
        maxHP = 50;
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>(); //애니메이션
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("너드남 데미지 들어감");
        //데미지를 입은 경우 최근체력 감소시킴
        StartCoroutine(DamageMotion());
        currentHP -= damage;
        GameManager.instance.setsummonenemyHP(currentHP);   //적 체력값 전달
        GameManager.instance.PlayEnemyHitSound();
        //보스가 생성하는 몹은 체력바를 띄우지 않는다.
        //체력이 0이면 플레이어 죽음
        if(currentHP <= 0) 
        {
            Debug.Log("Enemy HP : 0.. Die");
            Destroy(gameObject);
        }
    }
    //캐릭터 데미지 x이유 총알이 들어간걸 인식 x

    IEnumerator DamageMotion(){
        animator.SetBool("isHunted", true);
        yield return new WaitForSecondsRealtime(1.0f);
        animator.SetBool("isHunted", false);
    }
}
